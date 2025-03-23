using HarmonyLib;
using SpaceCraft;
using DespLib.Utilities;
using System.Collections.Generic;

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
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix runs for MachineGenerator.SetGeneratorInventory - OreExtractor1(Clone)[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : Intervall Spawn set to - 70 - before[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : Intervall Spawn set to - 75 - after[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix runs for MachineGenerator.SetGeneratorInventory - OreExtractor2(Clone)[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : Intervall Spawn set to - 65 - before[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : Intervall Spawn set to - 80 - after[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix runs for MachineGenerator.SetGeneratorInventory - OreExtractor3(Clone)[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : Intervall Spawn set to - 75 - before[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : Intervall Spawn set to - 80 - after[/ Debug]

            if (!Plugin.ModisActive.Value)
            {
                if (!__instance.name.Contains("OreExtractor1"))
                {
                    DFLogger.DFLogDebug($"prefix (MachineGenerator.SetGeneratorInventory) : Set Tier 1 Intervall back to Orignal while Game Runs");
                    __instance.spawnEveryXSec = Plugin.OriginalExtractionIntervaltier1;
                }
                else if (!__instance.name.Contains("OreExtractor2"))
                {
                    DFLogger.DFLogDebug($"prefix (MachineGenerator.SetGeneratorInventory) : Set Tier 2 Intervall back to Orignal while Game Runs");
                    __instance.spawnEveryXSec = Plugin.OriginalExtractionIntervaltier2;
                }
                else if (!__instance.name.Contains("OreExtractor3"))
                {
                    DFLogger.DFLogDebug($"prefix (MachineGenerator.SetGeneratorInventory) : Set Tier 3 Intervall back to Orignal while Game Runs");
                    __instance.spawnEveryXSec = Plugin.OriginalExtractionIntervaltier3;
                }
                return true;
            }
            //Make sure to only Patch the Extractors
            if (!__instance.name.Contains("OreExtractor")) return true;
            
            DFLogger.DFLogDebug($"prefix (MachineGenerator.SetGeneratorInventory) : Instance Name> {__instance.name}");
            DFLogger.DFLogDebug($"prefix (MachineGenerator.SetGeneratorInventory) : Intervall Spawn set to - {__instance.spawnEveryXSec} - before");

            if (__instance.name.Contains("OreExtractor1"))
            {
                DFLogger.DFLogDebug($"prefix (MachineGenerator.SetGeneratorInventory) : Set Tier 1 Intervall - {Plugin.OriginalExtractionIntervaltier1}");
                __instance.spawnEveryXSec = Plugin.ExtractionIntervaltier1.Value;
            }
            else if (__instance.name.Contains("OreExtractor2"))
            {
                DFLogger.DFLogDebug($"prefix (MachineGenerator.SetGeneratorInventory) : Set Tier 2 Intervall - {Plugin.OriginalExtractionIntervaltier2}");
                __instance.spawnEveryXSec = Plugin.ExtractionIntervaltier2.Value;
            }
            else if (__instance.name.Contains("OreExtractor3"))
            {
                DFLogger.DFLogDebug($"prefix (MachineGenerator.SetGeneratorInventory) : Set Tier 3 Intervall - {Plugin.OriginalExtractionIntervaltier3}");
                __instance.spawnEveryXSec = Plugin.ExtractionIntervaltier3.Value;
            }

            DFLogger.DFLogDebug($"prefix (MachineGenerator.SetGeneratorInventory) : Intervall Spawn set to - {__instance.spawnEveryXSec} - after");
            
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
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : runs for MachineGenerator.GenerateAnObject - OreExtractor1(Clone)[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Header - oreAllowedToMine[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - tier1[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Header - groupDatas[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Cobalt - hideinCrafter > False - ID > Cobalt[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Silicon - hideinCrafter > False - ID > Silicon[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Titanium - hideinCrafter > False - ID > Titanium[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Magnesium - hideinCrafter > False - ID > Magnesium[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Iron - hideinCrafter > False - ID > Iron[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Iron - hideinCrafter > False - ID > Iron[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - miningRays-> 1[/ Debug]

            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(MachineGenerator.GenerateAnObject) : runs for MachineGenerator.GenerateAnObject - OreExtractor2(Clone)[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Header - oreAllowedToMine[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - tier1[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - tier2[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Header - groupDatas[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Cobalt - hideinCrafter > False - ID > Cobalt[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Silicon - hideinCrafter > False - ID > Silicon[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Titanium - hideinCrafter > False - ID > Titanium[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Magnesium - hideinCrafter > False - ID > Magnesium[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - Name > Minable - Iron - hideinCrafter > False - ID > Iron[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(GenerateAnObject) : Data - miningRays-> 4[/ Debug]

            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(MachineGenerator.GenerateAnObject) : Instance Name> OreExtractor3(Clone)[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(MachineGenerator.GenerateAnObject) : Header - oreAllowedToMine[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(MachineGenerator.GenerateAnObject) : Data - tier1[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(MachineGenerator.GenerateAnObject) : Data - tier2[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(MachineGenerator.GenerateAnObject) : Header - groupDatas[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(MachineGenerator.GenerateAnObject) : Data - Name > Minable - Aluminium - hideinCrafter > False - ID > Aluminium[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(MachineGenerator.GenerateAnObject) : Data - Name > Minable - Aluminium - hideinCrafter > False - ID > Aluminium[/ Debug]
            //[Debug: Ore Extractor Focus][OreExtractorFocus][Debug] : prefix(MachineGenerator.GenerateAnObject) : Data - miningRays-> 1[/ Debug]

            if (!Plugin.ModisActive.Value) return true;
            //Make sure to only Patch the Extractors
            if (!__instance.name.Contains("OreExtractor")) return true;

            //------------------------------------------------------------------------------------------------
            //------------------------------------------------------------------------------------------------
            // /*

            //Even the Logger does not does Deeplogging it doesn't make sense to do all the Calls when not really needed.
            if (Plugin.Debuglogging.Value)
            {
                //Run a advanced Logging for Getting all Possible Configurations we need from an Extractor.
                DFLogger.DFLogDebug($"prefix (MachineGenerator.GenerateAnObject) : Instance Name> {__instance.name}");
                DFLogger.DFLogDebug($"prefix (MachineGenerator.GenerateAnObject) : Header - oreAllowedToMine");

                foreach (DataConfig.OreVeinIdentifer data in __instance.oreAllowedToMine)
                {
                    DFLogger.DFLogDebug($"prefix (MachineGenerator.GenerateAnObject) : Data - {data.ToString()}");
                }
                DFLogger.DFLogDebug($"prefix (MachineGenerator.GenerateAnObject) : Header - groupDatas");
                foreach (GroupData data in __instance.groupDatas)
                {
                    DFLogger.DFLogDebug($"prefix (MachineGenerator.GenerateAnObject) : Data - Name> {data.name} - hideinCrafter> {data.hideInCrafter} - ID> {data.id}");
                }

                DFLogger.DFLogDebug($"prefix (MachineGenerator.GenerateAnObject) : Data - miningRays -> {__instance.miningRays}");
            }

            //
            //------------------------------------------------------------------------------------------------
            //------------------------------------------------------------------------------------------------

            //The Extractor 3 has already a Focus Logic. So let us skip here.
            if (__instance.name.Contains("OreExtractor3")) return true;

            ///*
            if (__instance.groupDatas[(__instance.groupDatas.Count - 1)].id == "Iron")
            {
                //Default Extractor do not need changes
                return true;
            }
            else if (Plugin.UseStage.Value == 1)
            {
                //As Count - 1 always returns the Primary Ore this will always just extract this one.
                //WorldObject worldObject = WorldObjectsHandler.CreateNewWorldObject(GroupsHandler.GetGroupViaId(__instance.groupDatas[(__instance.groupDatas.Count - 1)].id), 0);
                //__instance.inventory.AddItem(worldObject);
                InventoriesHandler.Instance.AddItemToInventory( GroupsHandler.GetGroupViaId(__instance.groupDatas[(__instance.groupDatas.Count - 1)].id) , __instance.inventory, null);
                return false;
            }
            else if(Plugin.UseStage.Value == 2)
            {
                // In Szenario 2 the core Point is to dramaticly increase the return of the Primary ore while there is still a small by producte.
                // to archive this there is a 1 of x chance that the Original Code runs and generate a byproducte (or the primary Ore by luck).
                int maxrandomrange = Plugin.Extractionluck.Value;
                int random = UnityEngine.Random.Range(0, maxrandomrange);
                if (random == 0)
                {
                    //WorldObject worldObject = WorldObjectsHandler.CreateNewWorldObject(GroupsHandler.GetGroupViaId(__instance.groupDatas[UnityEngine.Random.Range(0, __instance.groupDatas.Count)].id), 0);
                    //__instance.inventory.AddItem(worldObject);
                    InventoriesHandler.Instance.AddItemToInventory(GroupsHandler.GetGroupViaId(__instance.groupDatas[UnityEngine.Random.Range(0, __instance.groupDatas.Count)].id), __instance.inventory, null);
                }
                else
                {
                    //WorldObject worldObject = WorldObjectsHandler.CreateNewWorldObject(GroupsHandler.GetGroupViaId(__instance.groupDatas[(__instance.groupDatas.Count - 1)].id), 0);
                    //__instance.inventory.AddItem(worldObject);
                    InventoriesHandler.Instance.AddItemToInventory(GroupsHandler.GetGroupViaId(__instance.groupDatas[(__instance.groupDatas.Count - 1)].id), __instance.inventory, null);
                }
                return false;
            }
            else
            {
                //In case of any kind of Error. Just proceed with the Original so we at least do not break something.
                return true;
            }
            //*/
        }
    }
}
