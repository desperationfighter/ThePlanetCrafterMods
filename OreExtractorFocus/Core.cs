using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Reflection;
using DespLib.Utilities;

/*
License: Reuploading of any File Content is prohibited either Original, Modified or Partly for other Projects.
If you have any Bugfixes may contact me with it and i will credit you in the next release.
 */

namespace OreExtractorFocus
{
    [BepInPlugin("Desperationfighter.TPC.OreExtractorFocus", "Ore Extractor Focus", "1.2.1.0")]
    public class BepInExPlugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> ModisActive;
        public static ConfigEntry<int> UseStage;
        public static ConfigEntry<int> Extractionluck;
        public static ConfigEntry<int> ExtractionIntervaltier1;
        public static ConfigEntry<int> ExtractionIntervaltier2;
        public static ConfigEntry<int> ExtractionIntervaltier3;
        public static ConfigEntry<bool> Debuglogging;

        private void Awake()
        {
            ModisActive = Config.Bind("1_General", "ModisActive", true, "Set if the Mod should running or not. If you don't want to remove Files or for Later Ingame Menu");
            UseStage = Config.Bind("1_General", "UseStage", 2, "Set wanted usage Methode. " +
                "0 = Just adjust Interval and let everything else Vanilla; " +
                "1 = Extract only Primary Ore and NEVER get any by Product; " +
                "2 = Focus on Primary ore. You still get a small amount of by product Ores");
            Extractionluck = Config.Bind("3_UseStage2-Subconfig", "Extractionluck", 2, "This config only applies when UseStage 2 is used. Its a 1 of X mechanic when you get eventually byproducts. For example Setting this to 1 mean 1 of 1 time you get eventually byproduct. Setting it on 2 means 1 of 2 Times you get eventually byproduct. 3 => 1 of 3 times eventually byproduct. In Percentage that means 33% of times you get a eventually random byproduct. But 2 Times gurantee the Primary Ore.");
            ExtractionIntervaltier1 = Config.Bind("2_General-Config", "ExtractionIntervaltier1", 80, "Affect Tier 1 Ore Exctrator -> Default value in Game = 70; Time span between two extraction tries. In exchange of getting more and faster Ores you want the Interval is slighly increased. Warning: Values below 10 can produce huge Performance lacks and fills the Invenotry in no time.");
            ExtractionIntervaltier2 = Config.Bind("2_General-Config", "ExtractionIntervaltier2", 75, "Affect Tier 2 Ore Exctrator -> Default value in Game = 65; Time span between two extraction tries. In exchange of getting more and faster Ores you want the Interval is slighly increased. Warning: Values below 10 can produce huge Performance lacks and fills the Invenotry in no time.");
            ExtractionIntervaltier3 = Config.Bind("2_General-Config", "ExtractionIntervaltier3", 75, "Affect Tier 3 Ore Exctrator -> Default value in Game = 75; Time span between two extraction tries. In exchange of getting more and faster Ores you want the Interval is slighly increased. Warning: Values below 10 can produce huge Performance lacks and fills the Invenotry in no time.");
            Debuglogging = Config.Bind("9_Advanced", "Debuglogging", false, "Enables Debug Logging. Should be only activated when you know what you do.");

            DFLogger.debugloggingenabled = Debuglogging.Value;
            DFLogger.logger = Logger;

            Logger.LogInfo("Try to apply Harmony Patches for - Desperationfighter.TPC.OreExtractorFocus");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
            DFLogger.DFLog($"Harmony Patches for {Assembly.GetExecutingAssembly().GetName().Name} were applied");
        }
    }
}
