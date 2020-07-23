using System;
using System.IO;
using System.Text;
using UnityEngine;
using System.Collections.Generic;

namespace FreemixLogSystem
{
    public class Postitplaced_EventLog : MonoBehaviour
    {
        private string actor, System;
        private EventCategory category, Status;
        private EventVerb eventType, PostitPlaced;
        private string objectName, Kitchen;
        private Dictionary<string, string> attributes, id_placed_postit;


        public Postitplaced_EventLog(EventCategory category, string actor, EventVerb eventType, string objectName, Dictionary<string, string> attributes = null)
        {
            this.category = Status;
            this.actor = System;
            this.eventType = PostitPlaced;
            this.objectName = Kitchen;
            this.attributes = id_placed_postit;
        }

        public override string ToString()
        {
            string stringAttributes = string.Empty;
            if (this.attributes != null)
                foreach (KeyValuePair<string, string> kv in this.attributes)
                    stringAttributes += string.Format("{0}:{1}|", kv.Key, kv.Value);

            return string.Format("{0};{1};{2};{3};{4}", this.category.ToString(), this.actor.ToString(), this.eventType.ToString(), this.objectName, stringAttributes);
        }
    }

}