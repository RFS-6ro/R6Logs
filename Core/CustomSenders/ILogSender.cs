// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using R6Logs.Core.Basic;

namespace R6Logs.Core.CustomSenders
{
    public interface ILogSender : IDisposable
    {
        string Name { get; }
        
        bool Send(Log formattedLog);
    }
}
