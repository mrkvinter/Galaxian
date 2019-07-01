using UnityEngine;

namespace Engine.Events
{
    public class ExplosionEvent : Event
    {
        public Vector3 Position { get; }

        public ExplosionEvent(GameObject sender, Vector3 position) : base(sender)
        {
            Position = position;
        }
    }
}