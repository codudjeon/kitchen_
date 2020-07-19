using System;
using System.IO;
using System.Text;
using UnityEngine;
using System.Collections.Generic;

namespace FreemixLogSystem
{
    public class EventLog : MonoBehaviour
    {
        private string actor,User, System;
        private EventCategory category, Acution, Status;
        private EventVerb eventType, Grab, Release, PostitPlaced, KitchenwarePlaced;
        private string objectName, Postit, Kitchenware, Kitchen;
        private Dictionary<string, string> attributes, id_postit, id_ghost, id_kitchenware, id_shelf, id_placed_postit, id_placed_kitchenware;

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