// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

#if R6_LOGS_ENABLED

namespace R6Logs.Core
{
    public enum LogLevel : byte
    {
        /// <summary>
        /// Used for debug purposes only
        /// </summary>
        Debug     = 0,

        ///<summary>
        /// Used for all additional info. Has own log history but also stored in common history
        /// </summary>
        Info      = 2,

        /// <summary>
        /// Used for non-critical unexpected behaviour
        /// </summary>
        Warning   = 3,

        /// <summary>
        /// Used for fatal errors in services
        /// </summary>
        Error     = 4,

        /// <summary>
        /// Used as separate log, same as error
        /// </summary>
        Exception  = 5,

        /// <summary>
        /// Used only for critical errors like failed assertions or service crash
        /// </summary>
        Critical  = 6,
    }
}

#endif
