using HarmonyLib;
using SpaceCraft;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LeteverythingfallonDeath.Patches
{
    /*
    [HarmonyPatch(typeof(DataConfig))]
    [HarmonyPatch(nameof(DataConfig.GameSettingDyingConsequences))]
    public static class DataConfig_Patch
    {
    /*
        [HarmonyPostfix]
        public static void Postfix(ref Enum __result)
        {
            Enum mytempenum = __result;
            var mytemparray = new ArrayList(Enum.GetValues(mytempenum.GetType()));
            mytemparray.Add("DropAllItems-Modded");
            __result = mytempenum.Select(a => (myEnum)Enum.Parse(typeof(myEnum), a));

            var stock = new ArrayList(__result);
            stock.AddRange(
                Enumerable.Range(0, InterfaceEntries.AllBones.Length)
                    .Select(x => Enum.ToObject(enumType, AccessoryParentKeyOriginalCount + x))
                    .ToArray());
            __result = stock.ToArray();

            //var stock = new ArrayList(__result);
            //stock.AddRange(Enumerable.Range(0, 1)..ToArray());
            //stock.Add("DropAllItems");
            //__result = stock.ToArray();
        }
    }
    

    enum MyEnum
    {
        DropAllItems
    }


    [HarmonyPatch(typeof(Enum))]
    [HarmonyPatch(nameof(Enum.GetValues))]
    public static class DataConfig_Patch_enum
    {
        public static void Postfix(ref Array __result)
        {
            Plugin.Logger.LogDebug("---------ENUM-------------------------------------");
            Plugin.Logger.LogDebug($"First: {__result.GetValue(0).ToString()}");
            Plugin.Logger.LogDebug($"Second {DataConfig.GameSettingDyingConsequences.NoConsequences.ToString()}");
            Plugin.Logger.LogDebug("---------ENUM-------------------------------------");
            //if (__result.GetValue(0).ToString() == DataConfig.GameSettingDyingConsequences.NoConsequences.ToString())
            //{
                //var stock = new ArrayList(__result);
                //stock.Add("DropAllItems");
                //__result = stock.ToArray();
            //}
        }
    }
    */
}
