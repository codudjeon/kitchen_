using System.IO;
using System.Text;
using UnityEngine;
using System.Collections.Generic;
using VRTK;

namespace FreemixLogSystem
{
    public class Postitplaced_EventLog : MonoBehaviour
    {
        public void LogOnGrab(UnityEngine.Object o, ControllerInteractionEventArgs e)
        {
            if (o)
                EventLogger.Log(new EventLog(EventCategory.action, "user", EventVerb.grab, ((GameObject)o).name), null);
        }

        public void LogOnUngrab(UnityEngine.Object o, ControllerInteractionEventArgs e)
        {
            if (o)
                EventLogger.Log(new EventLog(EventCategory.action, "user", EventVerb.ungrab, ((GameObject)o).name), null);
        }


        
    }
}