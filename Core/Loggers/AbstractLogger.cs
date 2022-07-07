// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using R6Logs.Core.Basic;
using R6Logs.Core.CustomSenders;

namespace R6Logs.Core.Loggers
{
    public abstract class AbstractLogger : ILogger
    {
#if UNITY_EDITOR
        private ILogSender _editorSender;
#endif
        
        protected AbstractLogger(LogLevel minimumLogLevel, LogOptions logOptions)
        {
#if UNITY_EDITOR
            _editorSender = new EditorSender();
#endif
            
            MinimumLogLevel = minimumLogLevel;
            LogOptions = logOptions;
#if !R6_LOGS_DISABLED
            History = new LogHistory();
#endif
        }

#if !R6_LOGS_DISABLED
        public LogHistory History { get; }
#endif
        
        public LogLevel MinimumLogLevel { get; }
        
        public LogOptions LogOptions { get; }

        private Log CreateLog
        (
            LogLevel level,
            string description,
            string message,
            IList<LogDataPair> additionalData,
            Exception exception
        )
        {
            return new Log(DateTime.Now, level, description, message, additionalData, exception);
        }

        protected virtual string FormatLogText
        (
            LogLevel level,
            string description,
            string message,
            IList<LogDataPair> additionalData,
            Exception exception
        )
        {
            return CreateLog(level, description, message, additionalData, exception).ToString();
        }

        public void Log
        (
            LogLevel level,
            string description,
            string message,
            IList<LogDataPair> additionalData,
            Exception exception,
            IEnumerable<ILogSender> senders
        )
        {
            Log log = CreateLog(level, description, message, additionalData, exception);

#if !R6_LOGS_DISABLED
            TryAddLogToHistory(log);
#endif
            
#if UNITY_EDITOR
            _editorSender.Send(log);
#endif
            
            if (level < MinimumLogLevel)
            {
                return;
            }
            
            if (senders == null)
            {
                return;
            }
            
            foreach (var sender in senders)
            {
                TrySendLog(sender, log);
            }
        }

#if !R6_LOGS_DISABLED
        private void TryAddLogToHistory(Log log)
        {
            if ((LogOptions & LogOptions.DoNotStore) == LogOptions.DoNotStore)
            {
                if ((LogOptions & LogOptions.RemoveDebug) != LogOptions.RemoveDebug || log.Level != LogLevel.Debug)
                {
                    History.AddLog(log);
                }
            }
        }
#endif

        private void TrySendLog(ILogSender sender, Log log)
        {
            if (!sender.Send(log))
            {
                Log
                (
                    LogLevel.Warning,
                    "Sender not responding",
                    $"Sender with name {sender.Name} is not responding and returns true on send",
                    null,
                    null,
                    null
                );
            }
        }
        
        public virtual void Dispose()
        {
#if UNITY_EDITOR
            _editorSender?.Dispose();
#endif
        }
    }
}
