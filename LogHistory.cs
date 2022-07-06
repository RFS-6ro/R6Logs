// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

#if R6_LOGS_ENABLED

using System.Collections.Generic;
using R6Logs.Core;

namespace R6Logs
{
    public class LogHistory
    {
        private Queue<Log> _commonHistory;
        private Queue<Log> _infoHistory;

        public LogHistory()
        {
            _commonHistory = new Queue<Log>();
            _infoHistory = new Queue<Log>();
        }

        public LogHistory(int maxLogNumber)
        {
            _commonHistory = new Queue<Log>(maxLogNumber);
            _infoHistory = new Queue<Log>(maxLogNumber);
        }

        public void AddLog(Log log)
        {
            
        }
    }
}

#endif
