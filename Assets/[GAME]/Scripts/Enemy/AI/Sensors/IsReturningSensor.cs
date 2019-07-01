using UnityEngine;

namespace Scripts.AI.AI.Sensors
{
    public class IsReturningSensor : BaseSensor
    {
        public const string IsReturningParameter = "IsReturning";

        private Ship ship;

        private void Start()
        {
            ship = GetComponent<Ship>();
        }

        public override (string key, bool value) CollectSensor()
        {
            return (IsReturningParameter, Vector3.Distance(ship.InFlockPosition, (Vector2) transform.position) < 0.05f);
        }
    }
}