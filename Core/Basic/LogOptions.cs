// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;

namespace R6Logs.Core.Basic
{
    [Flags]
    public enum LogOptions
    {
        Default = 0,
        
        /// <summary>
        /// log history would not be stored
        /// </summary>
        DoNotStore = 0x01,
        
        /// <summary>
        /// used for reducing debug spam in sent packet
        /// </summary>
        RemoveDebug = 0x02,
        
        IncludeStackTrace = 0x03
    }
}
