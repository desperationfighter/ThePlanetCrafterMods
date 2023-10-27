using HarmonyLib;
using SpaceCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/*
namespace LeteverythingfallonDeath.Patches
{
    [HarmonyPatch(typeof(DyingConsequencesHandler))]
    [HarmonyPatch(nameof(DyingConsequencesHandler.HandleDyingConsequences))]    
    public static class DyingConsequencesHandler_Patch_Postfix
    {
        [HarmonyPrefix]
        public static void Prefix()
        {
            DyingConsequencesHandler.percentageChanceToLoseItemOnDeathStandard = 100f;
        }

        [HarmonyPostfix]
        public static void Postfix(PlayerMainController _playerMainController, Group _containerGroup)
        {
            DataConfig.GameSettingDyingConsequences dyingConsequences = Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetDyingConsequences();
            if (dyingConsequences == DataConfig.GameSettingDyingConsequences.NoConsequences)
            {
                Inventory inventory = _playerMainController.GetPlayerBackpack().GetInventory();
                List<WorldObject> insideWorldObjects = inventory.GetInsideWorldObjects();
                if (insideWorldObjects.Count == 0)
                {
                    return;
                }
                if (insideWorldObjects.Count <= 1)
                {
                    DyingConsequencesHandler.percentageChanceToLoseItemOnDeathStandard = 100f;
                }
                GameObject gameObject = DyingConsequencesHandler.SpawnAndReturnCanister(_playerMainController.transform.position, _containerGroup);
                InventoryAssociated component = gameObject.GetComponent<InventoryAssociated>();
                gameObject.AddComponent<InventoryDestroyWhenEmpty>().SetReferenceInventory(component.GetInventory());
                if (component != null)
                {
                    Inventory inventory2 = component.GetInventory();
                    inventory2.SetSize(30);
                    Managers.GetManager<BaseHudHandler>().DisplayCursorText("Dying_Info_Drop_Some_Items", 6f, "");
                    for (int i = insideWorldObjects.Count - 1; i > -1; i--)
                    {
                        //if (DyingConsequencesHandler.percentageChanceToLoseItemOnDeathStandard > (float)Random.Range(0, 100))
                        //{
                        WorldObject worldObject = insideWorldObjects[i];
                        if ((!(worldObject.GetGroup() is GroupItem) || !((GroupItem)worldObject.GetGroup()).GetCantBeDestroyed()) && inventory2.AddItem(worldObject))
                        {
                            inventory.RemoveItem(worldObject, false);
                        }
                        //}
                    }
                    return;
                }
            }
        }
    }
}
*/