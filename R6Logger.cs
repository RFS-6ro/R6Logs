// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

#if R6_LOGS_ENABLED

using System.Diagnostics;
using R6Logs.Core.CustomSenders;
using R6Logs.Core.Loggers;

namespace R6Logs
{
    public static class R6Logger
    {
        private static ILogger _logger;
        private static ILogSender _logSender;

        public static void SetLogger(ILogger logger)
        {
            _logger = logger;
        }

        public static void SetLogSender(ILogSender logSender)
        {
            _logSender = logSender;
        }
        
        [DebuggerStepThrough]
        public static void Debug()
        {
            
        }
    }
}

#endif
