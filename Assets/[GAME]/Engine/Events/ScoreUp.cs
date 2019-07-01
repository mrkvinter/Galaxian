using UnityEngine;

namespace Engine.Events
{
    public class ScoreUp : Event
    {
        public Vector3 Position { get; }
        public int ScoreCount { get; }

        public ScoreUp(GameObject sender, Vector3 position, int scoreCount) : base(sender)
        {
            Position = position;
            ScoreCount = scoreCount;
        }
    }
}