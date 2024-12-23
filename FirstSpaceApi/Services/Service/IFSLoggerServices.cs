﻿using NLog;
using ILogger = NLog.ILogger;

namespace FirstSpaceApi.Services.Service
{
    public class IFSLoggerServices
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public IFSLoggerServices()
         {
        } 
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Info(message);
        public void LogWarn(string message) => logger.Warn(message);
    }
}
