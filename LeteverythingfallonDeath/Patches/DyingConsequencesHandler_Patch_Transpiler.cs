/*

using HarmonyLib;
using SpaceCraft;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace LeteverythingfallonDeath.Patches
{
    [HarmonyPatch(typeof(DyingConsequencesHandler))]
    [HarmonyPatch(nameof(DyingConsequencesHandler.HandleDyingConsequences))]
    public static class DyingConsequencesHandler_Patch_Transpiler
    {
        //Debug Logging - Deactivate before shipping
        private static bool debuglogging = true;
        //Deep Logging
        private static bool deeplogging = true;

        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            string classnamefordocu = "DyingConsequencesHandler_Patch";
            if (debuglogging && !deeplogging)
            {
                Plugin.Logger.LogDebug("Deeploging deactivated");
            }

            if (debuglogging)
            {
                Plugin.Logger.LogDebug($"Start Transpiler - {classnamefordocu}");
            }


//0x0013 : brtrue	System.Reflection.Emit.Label
//0x0014 : ret	
//0x0015 : ldloc.2	
//0x0016 : callvirt	Int32 get_Count()
//0x0017 : ldc.i4.4    <---------------------------------------------------------------------------------------------------------| I Want to patch this > PATCH 2
//0x0018 : bgt	System.Reflection.Emit.Label                                                                                    +1
//0x0019 : ldc.r4	100                                                                                                             +2
//0x001A : stsfld	System.Single percentageChanceToLoseItemOnDeathStandard                                                         +3
//0x001B : ldarg.0	                                                                                                            +4
//0x001C : callvirt	UnityEngine.Transform get_transform()                                                                       
//0x001D : callvirt	UnityEngine.Vector3 get_position()
//0x001E : ldarg.1	
//0x001F : call	UnityEngine.GameObject SpawnAndReturnCanister(UnityEngine.Vector3, SpaceCraft.Group)                            
//0x0020 : dup	

//0x0030 : callvirt	Void SetSize(Int32)
//0x0031 : call	SpaceCraft.BaseHudHandler GetManager[BaseHudHandler]()
//0x0032 : ldstr	Dying_Info_Drop_Some_Items
//0x0033 : ldc.r4	6
//0x0034 : ldstr	
//0x0035 : callvirt	Void DisplayCursorText(System.String, Single, System.String)
//0x0036 : ldloc.2	
//0x0037 : callvirt	Int32 get_Count()
//0x0038 : ldc.i4.1	                                                                                                            
//0x0039 : sub	
//0x003A : stloc.s	System.Int32 (5)                                                                                            
//0x003B : br	System.Reflection.Emit.Label
//0x003C : ldsfld	System.Single percentageChanceToLoseItemOnDeathStandard                                                         -1
//0x003D : ldc.i4.0	<-----------------------------------------------------------------------------------------------------------| INDEX + I Want to patch this > PATCH 1
//0x003E : ldc.i4.s	100                                                                                                         +1
//0x003F : call	Int32 Range(Int32, Int32)                                                                                       +2
//0x0040 : conv.r4	                                                                                                            +3
//0x0041 : ble.un	System.Reflection.Emit.Label                                                                                    +4
//0x0042 : ldloc.2	
//0x0043 : ldloc.s	System.Int32 (5)
//0x0044 : callvirt	SpaceCraft.WorldObject get_Item(Int32)


            // PATCH 1 --------------------------------------------------------------------------------------
            bool found = false;
            var Index = -1;
            var codes = new List<CodeInstruction>(instructions);

            //logging before
            if (debuglogging && deeplogging)
            {
                Plugin.Logger.LogDebug("Deep Logging pre-transpiler:");
                for (int k = 0; k < codes.Count; k++)
                {
                    Plugin.Logger.LogDebug((string.Format("0x{0:X4}", k) + $" : {codes[k].opcode.ToString()}	{(codes[k].operand != null ? codes[k].operand.ToString() : "")}"));
                }
            }

            //analyse the code to find the right place for injection
            if (debuglogging)
            {
                Plugin.Logger.LogDebug("Start code analyses");
            }
            for (var i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Ldc_I4_0 && codes[i+1].opcode == OpCodes.Ldc_I4_S && codes[i + 3].opcode == OpCodes.Conv_R4)
                {
                    if (debuglogging)
                    {
                        Plugin.Logger.LogDebug("Found IL Code Line for Index");
                        Plugin.Logger.LogDebug($"Index = {Index.ToString()}");
                    }
                    found = true;
                    Index = i;
                    break;
                }
            }

            if (debuglogging)
            {
                if (found)
                {
                    Plugin.Logger.LogDebug("found true");
                }
                else
                {
                    Plugin.Logger.LogDebug("found false");
                }
            }

            if (Index > -1)
            {
                if (debuglogging)
                {
                    Plugin.Logger.LogDebug("Index > -1");
                }
                Plugin.Logger.LogInfo($"Transpiler injectection position found - {classnamefordocu}");
                //codes[Index] = new CodeInstruction(OpCodes.Ldc_I4_S,100); //yeah done it the wrong way ?
                //codes.RemoveRange(Index+1, 0);
                //codes[Index+1] = new CodeInstruction(OpCodes.Ldc_I4_2);
                //codes.RemoveRange(Index+2,0);

                codes.RemoveRange(Index-1,6);
                //Index-1, 4
                //Index-1, 5
                //Index-1, 6
                //Index-1, 7
                //Index-2, 7
            }
            else
            {
                Plugin.Logger.LogError("Index was not found");
            }
      
            //if (debuglogging && deeplogging)
            //{
            //    Plugin.Logger.LogDebug("Deep Logging >>In the Middle<< -transpiler:");
            //    for (int k = 0; k < codes.Count; k++)
            //    {
            //        Plugin.Logger.LogDebug((string.Format("0x{0:X4}", k) + $" : {codes[k].opcode.ToString()}	{(codes[k].operand != null ? codes[k].operand.ToString() : "")}"));
            //    }
            //}

            // PATCH 2 --------------------------------------------------------------------------------------
            bool found2 = false;
            var Index2 = -1;

            //analyse the code to find the right place for injection
            if (debuglogging)
            {
                Plugin.Logger.LogDebug("Start code analyses -2");
            }
            for (var i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Ldc_I4_4 && codes[i + 4].opcode == OpCodes.Ldarg_0)        
                {
                    if (debuglogging)
                    {
                        Plugin.Logger.LogDebug("Found IL Code Line for Index2 -2");
                        Plugin.Logger.LogDebug($"Index2 = {Index2.ToString()} -2");
                    }
                    found2 = true;
                    Index2 = i;
                    break;
                }
            }

            if (debuglogging)
            {
                if (found2)
                {
                    Plugin.Logger.LogDebug("found2 true -2");
                }
                else
                {
                    Plugin.Logger.LogDebug("found2 false -2");
                }
            }

            if (Index2 > -1)
            {
                if (debuglogging)
                {
                    Plugin.Logger.LogDebug("Index2 > -1 |-2");
                }
                Plugin.Logger.LogInfo($"Transpiler injectection position found - {classnamefordocu} -2");
                //codes[Index2] = new CodeInstruction(OpCodes.Ldc_I4_1);
                //codes.RemoveRange(Index2 + 1, 0);
            }
            else
            {
                Plugin.Logger.LogError("Index2 was not found -2");
            }

            // --------------------------------------------------------------------------------------


            //logging after
            if (debuglogging && deeplogging)
            {
                Plugin.Logger.LogDebug("Deep Logging after-transpiler:");
                for (int k = 0; k < codes.Count; k++)
                {
                    Plugin.Logger.LogDebug((string.Format("0x{0:X4}", k) + $" : {codes[k].opcode.ToString()}	{(codes[k].operand != null ? codes[k].operand.ToString() : "")}"));
                }
            }

            if (debuglogging)
            {
                Plugin.Logger.LogDebug("Transpiler end going to return");
            }
            return codes.AsEnumerable();
        }
    }
}

*/