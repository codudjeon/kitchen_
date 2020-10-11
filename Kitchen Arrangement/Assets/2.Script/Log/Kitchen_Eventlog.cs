using UnityEngine;
using VRTK;

namespace FreemixLogSystem
{

    public class Kitchen_eventlog : MonoBehaviour
    {
        private GameObject GrabbedObject;

        public void LogOnGrab(object o, ControllerInteractionEventArgs e)
        {
            if (this.gameObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null)
            {
                this.GrabbedObject = this.gameObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
                
                EventLogger.Log(new EventLog(EventCategory.action, "user", EventVerb.grab, this.GrabbedObject.name));
            }
        }

        public void LogOnUngrab(object o, ControllerInteractionEventArgs e)
        {
            if (GrabbedObject != null)
            {
                EventLogger.Log(new EventLog(EventCategory.action, "user", EventVerb.ungrab, GrabbedObject.name));
                this.GrabbedObject = null;
            }
        }
    }
}