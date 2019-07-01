using UnityEngine;

namespace Engine.Events
{
    public class EnemyKilled : Event
    {
        public int ScoreCost;

        public EnemyKilled(GameObject sender, int scoreCost = 0) : base(sender)
        {
            ScoreCost = scoreCost;
        }
    }
}