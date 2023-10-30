using HarmonyLib;
using SpaceCraft;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace LeteverythingfallonDeath.Patches
{
    /*[HarmonyPatch(typeof(DyingConsequencesHandler), nameof(DyingConsequencesHandler.HandleDyingConsequences))]
    class DropAllGentlyBecauseILoveMyItems
    {
        static bool Prefix(PlayerMainController _playerMainController, Group _containerGroup)
        {
            if (SomeConfigYouMade.UseOriginal = True) return true;

            Inventory inventory = _playerMainController.GetPlayerBackpack().GetInventory();
            List<WorldObject> insideWorldObjects = inventory.GetInsideWorldObjects();
            if (insideWorldObjects.Count == 0)
            {
                return false;
            }

            GameObject gameObject = SpawnAndReturnCanister(_playerMainController.transform.position, _containerGroup);
            InventoryAssociated component = gameObject.GetComponent<InventoryAssociated>();
            gameObject.AddComponent<InventoryDestroyWhenEmpty>().SetReferenceInventory(component.GetInventory());
            if (component != null)
            {
                Inventory inventory2 = component.GetInventory();
                inventory2.SetSize(30);
                Managers.GetManager<BaseHudHandler>().DisplayCursorText("Dying_Info_Lost_All_Items", 6f, "In a canister!");
                for (int i = insideWorldObjects.Count - 1; i > -1; i--)
                {
                    WorldObject worldObject = insideWorldObjects[i];
                    if ((!(worldObject.GetGroup() is GroupItem) || !((GroupItem)worldObject.GetGroup()).GetCantBeDestroyed()) && inventory2.AddItem(worldObject))
                    {
                        inventory.RemoveItem(worldObject, false);
                    }
                }
            }

            return false;
        }
    }*/


















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
