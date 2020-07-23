using UnityEngine;
using VRTK;

namespace FreemixLogSystem
{

    public class Kitchen_eventlog : MonoBehaviour
    {
        public void LogOnGrab(Object o, ControllerInteractionEventArgs e)
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