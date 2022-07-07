// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace R6Logs.Core.Basic
{
    public class Log
    {
        private DateTime _time;
        private LogLevel _level;
        private string _description;
        private string _message;
        private Exception _exception;
        private LogDataPair[] _additionalData;

        public Log
        (
            DateTime time, 
            LogLevel level, 
            string description, 
            string message,
            IList<LogDataPair> additionalData, 
            Exception exception)
        {
            _time = time;
            _level = level;
            _description = description;
            _message = message;
            _exception = exception;

            if (additionalData == null)
            {
                return;
            }
            
            //TODO: consider if the array copy is necessary
            
#if !R6_EXTENSIONS_DISABLED 
            //TODO: add R6 extensions
            _additionalData = new LogDataPair[additionalData.Count];
            additionalData.CopyTo(_additionalData, 0);
#else
            _additionalData = new LogDataPair[additionalData.Count];
            additionalData.CopyTo(_additionalData, 0);
#endif
        }

        public DateTime Time => _time;                  

        public LogLevel Level => _level;                  

        public string Description => _description;                  

        public string Message => _message;                  

        public IReadOnlyCollection<LogDataPair> AdditionalData => _additionalData;

        public Exception Exception => _exception;

        public override string ToString()
        {
#if !R6_EXTENSIONS_DISABLED
            //TODO: add R6 extensions
            string formattedAdditionalData = FormatAdditionalData();
#else
            string formattedAdditionalData = FormatAdditionalData();
#endif

            return $"{Level}|[{Time}|{Description}|{Message}|{Exception}|{formattedAdditionalData}";
        }
        
        private string FormatAdditionalData()
        {
            StringBuilder builder = new StringBuilder();
            
            if (_additionalData != null)
            {
                builder.Append("**");
                foreach (var logDataPair in _additionalData)
                {
                    builder.Append("[");
                    builder.Append(logDataPair);
                    builder.Append("]");
                }
                builder.Append("**");
            }

            return builder.ToString();
        }
    }
}
