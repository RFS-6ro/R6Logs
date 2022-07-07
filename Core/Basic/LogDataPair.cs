// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

namespace R6Logs.Core.Basic
{
    public class LogDataPair
    {
        private string _pairName;
        
        public LogDataPair(string pairName)
        {
            _pairName = pairName;
        }

        public override string ToString()
        {
            return _pairName;
        }
    }
}
