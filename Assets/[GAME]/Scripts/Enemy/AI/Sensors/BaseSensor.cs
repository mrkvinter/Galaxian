using UnityEngine;

namespace Scripts.AI.AI.Sensors
{
    public abstract class BaseSensor : MonoBehaviour
    {
        public abstract (string key, bool value) CollectSensor();
    }
}