using HarmonyLib;
using SpaceCraft;
using DespLib.Utilities;

namespace OreExtractorFocus.Patches
{
    internal class MachineGenerator_Patch
    {
    }

    [HarmonyPatch(typeof(MachineGenerator))]
    [HarmonyPatch(nameof(MachineGenerator.SetGeneratorInventory))]
    static class MachineGenerator_SetGeneratorInventory_Patch
    {
        [HarmonyPrefix]
        static bool Prefix(MachineGenerator __instance)
        {
            if (!__instance.name.Contains("OreExtractor")) return true;
            DFLogger.DFLogDebug($"prefix runs for MachineGenerator.SetGeneratorInventory - {__instance.name}") ;
            DFLogger.DFLogDebug($"Intervall Spawn set to - {__instance.spawnEveryXSec} - before");
            __instance.spawnEveryXSec = BepInExPlugin.ExtractionInterval.Value;
            DFLogger.DFLogDebug($"Intervall Spawn set to - {__instance.spawnEveryXSec} - after");
            return true;
        }
    }

    [HarmonyPatch(typeof(MachineGenerator))]
    [HarmonyPatch(nameof(MachineGenerator.GenerateAnObject))]
    static class MachineGenerator_GenerateAnObject_Patch
    {
        [HarmonyPrefix]
        static bool Prefix(MachineGenerator __instance)
        {
            if (!__instance.name.Contains("OreExtractor")) return true;
            DFLogger.DFLogDebug($"prefix runs for MachineGenerator.GenerateAnObject - {__instance.name}");

            //------------------------------------------------------------------------------------------------
            /*
            Debug.Log("");
            Debug.Log($"Data - Name");
            Debug.Log($"{__instance.name}");
            Debug.Log($"Data - oreAllowedToMine");
            foreach (DataConfig.OreVeinIdentifer data in __instance.oreAllowedToMine)
            {
                Debug.Log($"{data.ToString()}");
            }
            Debug.Log($"Data - groupDatas");
            foreach (GroupData data in __instance.groupDatas)
            {
                Debug.Log($"Name: {data.name} - hideinCrafter: {data.hideInCrafter} - ID {data.id}");
            }
            Debug.Log($"Data - spawnEveryXSec");
            Debug.Log($"{__instance.spawnEveryXSec}");
            Debug.Log($"Data - miningRays");
            Debug.Log($"{__instance.miningRays}");
            */
            //------------------------------------------------------------------------------------------------

            if (BepInExPlugin.UseStage.Value == 1)
            {
                //As Count - 1 always returns the Primary Ore this will always just extract this one.
                WorldObject worldObject = WorldObjectsHandler.CreateNewWorldObject(GroupsHandler.GetGroupViaId(__instance.groupDatas[(__instance.groupDatas.Count - 1)].id), 0);
                __instance.inventory.AddItem(worldObject);
                return false;
            }
            else if(BepInExPlugin.UseStage.Value == 2)
            {
                // In Szenario 2 the core Point is to dramaticly increase the return of the Primary ore while there is still a small by producte.
                // to archive this there is a 1 of x chance that the Original Code runs and generate a byproducte (or the primary Ore by luck).
                int maxrandomrange = BepInExPlugin.Extractionluck.Value;
                if(maxrandomrange <= 0)
                { 
                    maxrandomrange = 1;
                }
                int random = UnityEngine.Random.Range(1, maxrandomrange);
                if(random == 1)
                {
                    WorldObject worldObject = WorldObjectsHandler.CreateNewWorldObject(GroupsHandler.GetGroupViaId(__instance.groupDatas[UnityEngine.Random.Range(0, __instance.groupDatas.Count)].id), 0);
                    __instance.inventory.AddItem(worldObject);
                }
                else
                {
                    WorldObject worldObject = WorldObjectsHandler.CreateNewWorldObject(GroupsHandler.GetGroupViaId(__instance.groupDatas[(__instance.groupDatas.Count - 1)].id), 0);
                    __instance.inventory.AddItem(worldObject);
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
