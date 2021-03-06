// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using R6Logs.Core.Basic;
using R6Logs.Core.CustomSenders;

namespace R6Logs.Core.Loggers
{
    public class EditorLogger : AbstractLogger
    {
        public EditorLogger(LogLevel minimumLogLevel, LogOptions logOptions) : base(minimumLogLevel, logOptions) { }

        // public override void Log(LogLevel level, string description, string message, IList<LogDataPair> additionalData, ILogSender sender)
        // {
        //     
        // }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
