using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace FreemixLogSystem
{
    public class EventLogger : MonoBehaviour
    {
        private static readonly object innerLock = new object();
        private static string path;


        // Use this for initialization
        void Start()
        {
            path = LogManager.directory + "/Events-" + LogManager.userName + "-" + LogManager.currentDt + ".csv";
            print(path);
            File.AppendAllText(path, "AppTime;EventCategory;Actor;EventType;Object;Attributes\n", Encoding.UTF8);
        }

        public static void Log(EventLog e)
        {
            lock (innerLock)
            {
                File.AppendAllText(path, String.Format("{0};{1};\n", Time.realtimeSinceStartup, e.ToString()), Encoding.UTF8);
            }
        }
    }

}