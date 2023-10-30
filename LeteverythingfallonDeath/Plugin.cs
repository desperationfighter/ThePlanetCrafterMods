using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

/*
License: Reuploading of any File Content is prohibited either Original, Modified or Partly for other Projects.
If you have any Bugfixes may contact me with it and i will credit you in the next release.
 */

namespace LeteverythingfallonDeath
{
    [BepInPlugin("Desperationfighter.TPC.LeteverythingfallonDeath", "Let everything fall on Death", "1.0.2.0")]
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