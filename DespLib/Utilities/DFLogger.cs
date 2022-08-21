using BepInEx.Logging;
using System;
using System.Reflection;

namespace DespLib.Utilities
{
    public static class DFLogger
    {
        static ManualLogSource logger;

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
            Assembly assembly = Assembly.GetExecutingAssembly();
            //Debug.Log($"[{assembly.FullName}] - [{dFLogger}] : {Message}");

            switch(dFLogger)
            {
                case DFLogLevel.Debug:
                    Type type = assembly.GetType("BepInExPlugin");
                    PropertyInfo propertyInfo = type.GetProperty("Debuglogging");
                    if(propertyInfo.PropertyType == typeof(bool))
                    {
                        if((bool)propertyInfo.GetValue("Debuglogging"))
                        {
                            logger.Log(LogLevel.Debug, Message);
                        }
                        else
                        {
                            logger.Log(LogLevel.Debug, "error on debug logging 2");
                        }
                    }
                    else
                    {
                        logger.Log(LogLevel.Debug, "error on debug logging");
                    }
                    break;
                case DFLogLevel.Information:
                    logger.Log(LogLevel.Info, Message);
                    break;
                case DFLogLevel.Warning:
                    logger.Log(LogLevel.Warning, Message);
                    break;
                case DFLogLevel.Error:
                    logger.Log(LogLevel.Error, Message);
                    break;
                case DFLogLevel.Fatal:
                    logger.Log(LogLevel.Fatal, Message);
                    break;
            }
        }
    }
}
