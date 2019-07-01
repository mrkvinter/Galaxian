using System;
using Engine;
using Engine.Events;
using UnityEngine;

namespace Scripts
{
    public class ScoreController : MonoBehaviour
    {
        public int Score;

        private Action<EnemyKilled> handler;

        private void Start()
        {
            handler = e =>
            {
                var commonScore = e.ScoreCost;
                Score += commonScore;
                EventSystem.Instance.Notify(new ScoreUp(gameObject, e.Sender.transform.position, commonScore));
            };
            EventSystem.Instance.Subscribe(handler);
        }

        private void OnDestroy()
        {
            EventSystem.Instance.Unsubscribe(handler);
        }
    }
}