using System;
using System.IO;
using UnityEngine;

namespace FreemixLogSystem
{
    public class LogManager : MonoBehaviour
    {
        public static string userName = "user";
        public static string directory { get; private set; }
        public static string currentDt { get; private set; }

        private void Awake()
        {
            LogManager.currentDt = DateTime.Now.ToString("yyyyMMddHHmmss");
            LogManager.directory = "Logs-" + userName + LogManager.currentDt;
            if (!Directory.Exists(LogManager.directory))
                Directory.CreateDirectory(LogManager.directory);
        }
    }
}
