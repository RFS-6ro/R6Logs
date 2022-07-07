// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using R6Logs.Core.Basic;
using R6Logs.Core.CustomSenders;

#if !R6_ATTRIBUTES_DISABLED
using JetBrains.Annotations; //TODO: add R6 attributes
#else
using JetBrains.Annotations;
#endif

namespace R6Logs.Core.Loggers
{
    public interface ILogger : IDisposable
    {
#if !R6_LOGS_DISABLED
        LogHistory History { get; }
#endif

        LogLevel MinimumLogLevel { get; }

        LogOptions LogOptions { get; }

        void Log
        (
            LogLevel level,

            #region description

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull] string description,
#else
            [CanBeNull] string description,
#endif

            #endregion

            #region message

#if !R6_ATTRIBUTES_DISABLED
            [NotNull] string message,
#else
            [NotNull] string message,
#endif

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
            [CanBeNull]
#else
            [CanBeNull]
#endif
            Exception exception,

            #endregion

            #region senders

#if !R6_ATTRIBUTES_DISABLED
            [CanBeNull, ItemNotNull]
#else
            [CanBeNull, ItemNotNull]
#endif
            IEnumerable<ILogSender> senders

            #endregion

        );
    }
}
