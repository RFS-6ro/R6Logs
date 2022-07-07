// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using R6Logs.Core.Basic;
using R6Logs.Core.CustomSenders;
using R6Logs.Core.Loggers;

#if !R6_ATTRIBUTES_DISABLED
using JetBrains.Annotations; //TODO: add R6 attributes
#else
using JetBrains.Annotations;
#endif

namespace R6Logs.Core
{
    public static class R6Logger
    {
#if !R6_LOGS_DISABLED
        private static LogHistory _history;
#endif

        private static ILogger _logger;
#if !R6_LOGS_DISABLED
        private static List<ILogSender> _senders;
#endif

        static R6Logger()
        {
#if !R6_LOGS_DISABLED
            _history = new LogHistory();
#endif
        }

        private static ILogger Logger
        {
            get
            {
                if (_logger == null)
                {
#if UNITY_EDITOR && !DEBUG
                    UnityEngine.Debug.LogWarning("Logger is not set. Default unity logger is used instead");
#endif

                    _logger = new EditorLogger(LogLevel.Debug, LogOptions.DoNotStore);
                }

                return _logger;
            }
            set => _logger = value;
        }

#if !R6_LOGS_DISABLED
        private static List<ILogSender> Senders
        {
            get
            {
                if (_senders == null)
                {
                    _senders = new List<ILogSender>();
                }

                return _senders;
            }
            set => _senders = value;
        }
#endif

#if !R6_LOGS_DISABLED
        public static void SetLogger
        (
#if !R6_ATTRIBUTES_DISABLED 
            [NotNull] //TODO: add R6 attributes
#else
            [NotNull]
#endif
            ILogger logger
        )
        {
            Logger?.Dispose();
            Logger = logger;
        }
#endif


#if !R6_LOGS_DISABLED
        public static void AddLogSender
        (
#if !R6_ATTRIBUTES_DISABLED 
            [NotNull] //TODO: add R6 attributes
#else
            [NotNull]
#endif
            ILogSender sender
        )
        {
            if (!Senders.Contains(sender))
            {
                Senders.Add(sender);
            }
        }
#endif


#if !R6_LOGS_DISABLED
        public static void RemoveLogSender
        (
#if !R6_ATTRIBUTES_DISABLED 
            [NotNull] //TODO: add R6 attributes
#else
            [NotNull]
#endif
            ILogSender sender
        )
        {
            if (_senders == null)
            {
#if UNITY_EDITOR
                UnityEngine.Debug.LogWarning("Trying to remove sender from empty senders list");
#endif
                return;
            }

            if (Senders.Contains(sender))
            {
                Senders.Remove(sender);
            }
        }
#endif

#if !R6_LOGS_DISABLED
        public static void SetLogSenders
        (
#if !R6_ATTRIBUTES_DISABLED 
            [NotNull, ItemNotNull] //TODO: add R6 attributes
#else
            [NotNull, ItemNotNull]
#endif
            IEnumerable<ILogSender> senders
        )
        {
            if (_senders != null)
            {
                foreach (var sender in Senders)
                {
                    sender.Dispose();
                }
                Senders.Clear();
            }
            
            Senders = senders.ToList();
        }
#endif

        [DebuggerStepThrough]
        public static void Debug
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Debug, null, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Debug
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Debug, null, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Debug
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Debug, description, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Debug
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Debug, description, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Debug
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Debug, null, message, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Debug
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Debug, null, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Debug
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Debug, description, message + exception, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Debug
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Debug, description, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Info
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Info, null, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Info
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Info, null, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Info
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Info, description, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Info
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Info, description, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Info
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Info, null, message, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Info
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Info, null, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Info
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Info, description, message + exception, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Info
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Info, description, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }
        
        [DebuggerStepThrough]
        public static void Warning
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Warning, null, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Warning
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Warning, null, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Warning
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Warning, description, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Warning
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Warning, description, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Warning
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Warning, null, message, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Warning
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Warning, null, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Warning
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Warning, description, message + exception, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Warning
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Warning, description, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }
        
        [DebuggerStepThrough]
        public static void Error
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Error, null, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Error
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Error, null, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Error
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Error, description, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Error
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Error, description, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Error
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Error, null, message, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Error
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Error, null, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Error
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Error, description, message + exception, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Error
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Error, description, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Exception
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Exception, null, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Exception
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Exception, null, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Exception
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Exception, description, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Exception
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Exception, description, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Exception
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Exception, null, message, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Exception
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Exception, null, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Exception
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Exception, description, message + exception, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Exception
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Exception, description, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Critical
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Critical, null, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Critical
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Critical, null, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Critical
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message

            #endregion
        )
        {
            Logger.Log(LogLevel.Critical, description, message, null, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Critical
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData

            #endregion
        )
        {
            Logger.Log(LogLevel.Critical, description, message, additionalData, null,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Critical
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Critical, null, message, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Critical
        (
            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Critical, null, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Critical
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Critical, description, message + exception, null, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }

        [DebuggerStepThrough]
        public static void Critical
        (
            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull]
#else
            [CanBeNull]
#endif
            string description,

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            string message,

            #endregion

            #region additionalData

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IList<LogDataPair> additionalData,

            #endregion

            #region exception

#if !R6_ATTRIBUTES_DISABLED
            [NotNull]
#else
            [NotNull]
#endif
            System.Exception exception

            #endregion
        )
        {
            Logger.Log(LogLevel.Critical, description, message + exception, additionalData, exception,
#if !R6_LOGS_DISABLED
                _senders);
#else
                null);
#endif
        }
    }
}
