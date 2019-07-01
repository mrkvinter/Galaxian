using UnityEngine;

namespace Scripts.AI.AI.Sensors
{
    public class PlayerIsAliveSensor : BaseSensor
    {
        public const string PlayerIsAliveParameter = "PlayerIsAlive";

        private GameObject player;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
        }


        public override (string key, bool value) CollectSensor()
        {
            return (PlayerIsAliveParameter, player != null);
        }
    }
}