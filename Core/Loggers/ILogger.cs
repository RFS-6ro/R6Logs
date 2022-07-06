// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

#if R6_LOGS_ENABLED

#if R6_ATTRIBUTES_ENABLED
using JetBrains.Annotations; //TODO: add R6 attributes
#else
using JetBrains.Annotations;
#endif
using R6Logs.Core.CustomSenders;

namespace R6Logs.Core.Loggers
{
    public interface ILogger
    {
        LogLevel MinimumLogLevel { get; }
        
        LogOptions LogOptions { get; }
        
        void Log
        (
            LogLevel level,
            #region description

#if R6_ATTRIBUTES_ENABLED
            [NotNull] string description,
#else
            [NotNull] string description,
#endif

            #endregion
            #region message

#if R6_ATTRIBUTES_ENABLED
            [NotNull] string message,
#else
            [NotNull] string message,
#endif

            #endregion
            LogHistory history,
            ILogSender sender
        );
    }
}

#endif
