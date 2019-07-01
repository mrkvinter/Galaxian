using UnityEngine;

namespace Engine.Events
{
    public class PlayerDied : Event
    {
        public PlayerDied(GameObject sender) : base(sender)
        {
        }
    }
}