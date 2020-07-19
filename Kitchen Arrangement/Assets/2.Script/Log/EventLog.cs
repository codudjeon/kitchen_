using System;
using System.IO;
using System.Text;
using UnityEngine;
using System.Collections.Generic;

namespace FreemixLogSystem
{
    public class EventLog : MonoBehaviour
    {
        private string actor;
        private EventCategory category;
        private EventVerb eventType;
        private string objectName;
        private Dictionary<string, string> attributes;

        public EventLog(EventCategory category, string actor, EventVerb eventType, string objectName, Dictionary<string, string> attributes = null)
        {
            this.category = category;
            this.actor = actor;
            this.eventType = eventType;
            this.objectName = objectName;
            this.attributes = attributes;
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