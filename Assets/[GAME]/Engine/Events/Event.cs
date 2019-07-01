using UnityEngine;

namespace Engine.Events
{
    public class Event
    {
        public GameObject Sender { get; }

        public Event(GameObject sender)
        {
            Sender = sender;
        }
    }
}