using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FreemixCommon;
using UnityEngine;

namespace FreemixLogSystem
{
    public abstract class TrajectoryLogger : MonoBehaviour
    {
        private string path;

        // Start is called before the first frame update
        void Start()
        {
            path = LogManager.directory + @"\Trajectory-" + gameObject.name + "-" + LogManager.currentDt + ".csv";
            string header = "AppTime;PosX;PosY;PosZ;RotX;RotY;RotZ;RotW;" + Environment.NewLine;
            File.AppendAllText(path, header);
        }

        protected void Log()
        {
            string s = string.Join(";", new string[] {
            Time.realtimeSinceStartup.ToString(),
            this.transform.position.Format(),
            this.transform.rotation.Format() }) + Environment.NewLine;
            File.AppendAllText(path, s);
        }

    }

}