//Saves an instanteneous log of data containing information such as the current altitude, the number of falls, the framerate, etc.

using UnityEngine;
using System;
using System.IO;
using FreemixCommon;

namespace FreemixLogSystem
{
    public class CommonDataLogger : MonoBehaviour
    {
        public GameObject Camera;
        public GameObject LeftController;
        public GameObject RightController;

        private string path;

        // Use this for initialization
        void Start()
        {
            if (Camera == null)
                Debug.LogError("main camera tracker missing");

            path = LogManager.directory + "/Common-" + LogManager.userName + LogManager.currentDt + ".csv";
            string header = "AppTime;HMDPosX;HMDPosY;HMDPosZ;HMDRotX;HMDRotY;HMDRotZ;HMDRotW;LeftPosX;LeftPosY;LeftPosZ;LeftRotX;LeftRotY;LeftRotZ;LeftRotW;RightPosX;RightPosY;RightPosZ;RightRotX;RightRotY;RightRotZ;RightRotW;" + Environment.NewLine;
            File.AppendAllText(path, header);

        }

        // Update is called once per frame
        void LateUpdate()
        {
            string s = string.Join(";", new string[] {
            Time.realtimeSinceStartup.ToString(),
            Camera.transform.position.Format(),
            Camera.transform.rotation.Format(),
            LeftController != null && LeftController.activeInHierarchy ? LeftController.transform.position.Format() : string.Empty,
            LeftController != null && LeftController.activeInHierarchy ? LeftController.transform.rotation.Format() : string.Empty,
            RightController != null && RightController.activeInHierarchy ? RightController.transform.position.Format() : string.Empty,
            RightController != null && RightController.activeInHierarchy ? RightController.transform.rotation.Format() : string.Empty });

            s += Environment.NewLine;
            File.AppendAllText(path, s);
        }
    }

}
