using System;
using System.Collections.Generic;
using R6Logs.Core;
using R6Logs.Core.Basic;
using UnityEngine;

namespace R6Logs
{
    public class TestMonoBehaviour : MonoBehaviour
    {
        private void Start()
        {
            R6Logger.Debug("Message1");
            R6Logger.Debug("Message2", new Exception("Exception1"));
            R6Logger.Debug("Message3", new List<LogDataPair>() {new LogDataPair("1")});
            R6Logger.Debug("Message4", new List<LogDataPair>() {new LogDataPair("2")}, new Exception("Exception2"));
            
            R6Logger.Debug("description1", "Message5");
            R6Logger.Debug("description2", "Message6", new Exception("Exception3"));
            R6Logger.Debug("description3", "Message7", new List<LogDataPair>() {new LogDataPair("3")});
            R6Logger.Debug("description4", "Message8", new List<LogDataPair>() {new LogDataPair("4")}, new Exception("Exception4"));
           
            R6Logger.Info("Message1");
            R6Logger.Info("Message2", new Exception("Exception1"));
            R6Logger.Info("Message3", new List<LogDataPair>() {new LogDataPair("1")});
            R6Logger.Info("Message4", new List<LogDataPair>() {new LogDataPair("2")}, new Exception("Exception2"));
            
            R6Logger.Info("description1", "Message5");
            R6Logger.Info("description2", "Message6", new Exception("Exception3"));
            R6Logger.Info("description3", "Message7", new List<LogDataPair>() {new LogDataPair("3")});
            R6Logger.Info("description4", "Message8", new List<LogDataPair>() {new LogDataPair("4")}, new Exception("Exception4"));
           
            R6Logger.Warning("Message1");
            R6Logger.Warning("Message2", new Exception("Exception1"));
            R6Logger.Warning("Message3", new List<LogDataPair>() {new LogDataPair("1")});
            R6Logger.Warning("Message4", new List<LogDataPair>() {new LogDataPair("2")}, new Exception("Exception2"));
            
            R6Logger.Warning("description1", "Message5");
            R6Logger.Warning("description2", "Message6", new Exception("Exception3"));
            R6Logger.Warning("description3", "Message7", new List<LogDataPair>() {new LogDataPair("3")});
            R6Logger.Warning("description4", "Message8", new List<LogDataPair>() {new LogDataPair("4")}, new Exception("Exception4"));
           
            R6Logger.Error("Message1");
            R6Logger.Error("Message2", new Exception("Exception1"));
            R6Logger.Error("Message3", new List<LogDataPair>() {new LogDataPair("1")});
            R6Logger.Error("Message4", new List<LogDataPair>() {new LogDataPair("2")}, new Exception("Exception2"));
            
            R6Logger.Error("description1", "Message5");
            R6Logger.Error("description2", "Message6", new Exception("Exception3"));
            R6Logger.Error("description3", "Message7", new List<LogDataPair>() {new LogDataPair("3")});
            R6Logger.Error("description4", "Message8", new List<LogDataPair>() {new LogDataPair("4")}, new Exception("Exception4"));
           
            R6Logger.Exception("Message1");
            R6Logger.Exception("Message2", new Exception("Exception1"));
            R6Logger.Exception("Message3", new List<LogDataPair>() {new LogDataPair("1")});
            R6Logger.Exception("Message4", new List<LogDataPair>() {new LogDataPair("2")}, new Exception("Exception2"));
            
            R6Logger.Exception("description1", "Message5");
            R6Logger.Exception("description2", "Message6", new Exception("Exception3"));
            R6Logger.Exception("description3", "Message7", new List<LogDataPair>() {new LogDataPair("3")});
            R6Logger.Exception("description4", "Message8", new List<LogDataPair>() {new LogDataPair("4")}, new Exception("Exception4"));
           
            R6Logger.Critical("Message1");
            R6Logger.Critical("Message2", new Exception("Exception1"));
            R6Logger.Critical("Message3", new List<LogDataPair>() {new LogDataPair("1")});
            R6Logger.Critical("Message4", new List<LogDataPair>() {new LogDataPair("2")}, new Exception("Exception2"));
            
            R6Logger.Critical("description1", "Message5");
            R6Logger.Critical("description2", "Message6", new Exception("Exception3"));
            R6Logger.Critical("description3", "Message7", new List<LogDataPair>() {new LogDataPair("3")});
            R6Logger.Critical("description4", "Message8", new List<LogDataPair>() {new LogDataPair("4")}, new Exception("Exception4"));
        }
    }
}