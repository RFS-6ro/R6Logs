// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using R6Logs.Core.Basic;
using UnityEngine;

namespace R6Logs.Core.CustomSenders
{
    public class ConsoleSender : ILogSender
    {
        public string Name { get; } = "Unity Editor";

        public bool Send(Log log)
        {
#if UNITY_EDITOR
            switch (log.Level)
            {
                case LogLevel.Debug:
                    Debug.Log(log);
                    break;
                case LogLevel.Info:
                    Debug.Log(log);
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning(log);
                    break;
                case LogLevel.Error:
                    Debug.LogError(log);
                    break;
                case LogLevel.Exception:
                    Debug.LogError(log);
                    break;
                case LogLevel.Critical:
                    Debug.LogError(log);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
#endif
            return true;
        }
        
        public void Dispose()
        {
        }
    }
}
