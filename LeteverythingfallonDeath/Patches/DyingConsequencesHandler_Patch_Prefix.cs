using HarmonyLib;
using SpaceCraft;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace LeteverythingfallonDeath.Patches
{
    [HarmonyPatch(typeof(DyingConsequencesHandler))]
    [HarmonyPatch(nameof(DyingConsequencesHandler.HandleDyingConsequences))]
    public static class DyingConsequencesHandler_Patch_Prefix
    {
        [HarmonyPrefix]
        public static bool Prefix(PlayerMainController _playerMainController, Group _containerGroup)
        {
            MyPrefixStuff(_playerMainController, _containerGroup);
            return false;
        }

        public static void MyPrefixStuff(PlayerMainController _playerMainController, Group _containerGroup)
        {
            DataConfig.GameSettingDyingConsequences dyingConsequences = Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetDyingConsequences();
            if (dyingConsequences == DataConfig.GameSettingDyingConsequences.NoConsequences)
            {
                return;
            }
            if (dyingConsequences == DataConfig.GameSettingDyingConsequences.DropSomeItems)
            {
                Inventory inventory = _playerMainController.GetPlayerBackpack().GetInventory();
                List<WorldObject> insideWorldObjects = inventory.GetInsideWorldObjects();
                if (insideWorldObjects.Count == 0)
                {
                    return;
                }
                //if (insideWorldObjects.Count <= 4)
                //{
                    //DyingConsequencesHandler.percentageChanceToLoseItemOnDeathStandard = 100f;
                //}
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
            else
            {
                if (dyingConsequences == DataConfig.GameSettingDyingConsequences.DropAllItems)
                {
                    Inventory inventory3 = _playerMainController.GetPlayerBackpack().GetInventory();
                    List<WorldObject> insideWorldObjects2 = inventory3.GetInsideWorldObjects();
                    for (int j = insideWorldObjects2.Count - 1; j > -1; j--)
                    {
                        WorldObject worldObject2 = insideWorldObjects2[j];
                        if (!(worldObject2.GetGroup() is GroupItem) || !((GroupItem)worldObject2.GetGroup()).GetCantBeDestroyed())
                        {
                            inventory3.RemoveItem(worldObject2, true);
                        }
                    }
                    Managers.GetManager<BaseHudHandler>().DisplayCursorText("Dying_Info_Lost_All_Items", 6f, "");
                    return;
                }
                if (dyingConsequences == DataConfig.GameSettingDyingConsequences.DeleteSaveFile)
                {
                    JSONExport.DeleteSaveFile(Managers.GetManager<SavedDataHandler>().GetCurrentSaveFileName());
                    SceneManager.LoadScene("Intro");
                }
            }
        }
    }
}
