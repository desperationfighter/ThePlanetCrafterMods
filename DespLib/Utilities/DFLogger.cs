using BepInEx.Logging;
using System;
using System.Reflection;
using SpaceCraft;
using HarmonyLib;
using System.Collections.Generic;
using MijuTools;


namespace DespLib.Utilities
{
    public static class DFLogger
    {
        public static ManualLogSource logger;
        public static bool debugloggingenabled;
        private static Assembly assembly => Assembly.GetExecutingAssembly();

        public enum DFLogLevel
        {
            Debug,
            Information,
            Warning,
            Error,
            Fatal
        }

        public static void DFLogDebug(string Message)
        {
            DFLog(Message, DFLogLevel.Debug);
        }
        public static void DFLogInfomration(string Message)
        {
            DFLog(Message, DFLogLevel.Information);
        }
        public static void DFLogWarning(string Message)
        {
            DFLog(Message, DFLogLevel.Warning);
        }
        public static void DFLogError(string Message)
        {
            DFLog(Message, DFLogLevel.Error);
        }
        public static void DFLogFatal(string Message)
        {
            DFLog(Message, DFLogLevel.Fatal);
        }

        public static void DFLog(string Message)
        {
            DFLog(Message, DFLogLevel.Information);
        }

        public static void DFLog(string Message,DFLogger.DFLogLevel dFLogger)
        {
            switch(dFLogger)
            {
                case DFLogLevel.Debug:
                    if(debugloggingenabled)
                    {
                        logger.Log(LogLevel.Debug,$"[{assembly.GetName().Name}] [{dFLogger.ToString()}] : {Message} [/{dFLogger.ToString()}]");
                    }
                    break;
                case DFLogLevel.Information:
                    logger.Log(LogLevel.Info, $"[{assembly.GetName().Name}] [{dFLogger.ToString()}] : {Message} [/{dFLogger.ToString()}]");
                    break;
                case DFLogLevel.Warning:
                    logger.Log(LogLevel.Warning, $"[{assembly.GetName().Name}] [{dFLogger.ToString()}] : {Message} [/{dFLogger.ToString()}]");
                    break;
                case DFLogLevel.Error:
                    logger.Log(LogLevel.Error, $"[{assembly.GetName().Name}] [{dFLogger.ToString()}] : {Message} [/{dFLogger.ToString()}]");
                    break;
                case DFLogLevel.Fatal:
                    logger.Log(LogLevel.Fatal, $"[{assembly.GetName().Name}] [{dFLogger.ToString()}] : {Message} [/{dFLogger.ToString()}]");
                    if (Managers.GetManager<PopupsHandler>() != null)
                    {
                        AccessTools.FieldRefAccess<PopupsHandler, List<PopupData>>(Managers.GetManager<PopupsHandler>(), "popupsToPop").Add(new PopupData(null, $"Fatal Error in Mod {assembly.GetName().Name} - See Logs for Details", 2));
                    }
                    break;
            }
        }
    }
}
