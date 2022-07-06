// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

#if R6_LOGS_ENABLED

using System;
using System.Collections.Generic;
using System.Linq;

namespace R6Logs.Core
{
    public class Log
    {
        private DateTime _time;
        private LogDataPair[] _additionalData;

        public Log(DateTime time, IList<LogDataPair> additionalData)
        {
            _time = time;
#if R6_EXTENSIONS_ENABLED
            //TODO: add R6 extensions
#else
            _additionalData = new LogDataPair[additionalData.Count];
            additionalData.CopyTo(_additionalData, 0);
#endif
        }
    }
}

#endif
