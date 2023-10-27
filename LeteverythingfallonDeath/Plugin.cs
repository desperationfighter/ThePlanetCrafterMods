using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace LeteverythingfallonDeath
{
    [BepInPlugin("Desperationfighter.Planetcrafter.LeteverythingfallonDeath", "Let everything fall on Death", "1.0.0.0")]
    public partial class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }

        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "Desperationfighter.Planetcrafter.LeteverythingfallonDeath");
            Logger.LogInfo("Plugin Desperationfighter.Planetcrafter.LeteverythingfallonDeath is loaded!");
        }
    }
}