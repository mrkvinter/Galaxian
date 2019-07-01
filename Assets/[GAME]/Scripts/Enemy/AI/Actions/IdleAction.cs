using System.Collections.Generic;
using Scripts.AI.AI.Sensors;

namespace Scripts.AI.AI.Actions
{
    public class IdleAction : BaseActionNode
    {
        private Ship ship;

        private void Start()
        {
            ship = GetComponent<Ship>();
        }

        public override bool IsCanStart(Dictionary<string, bool> parameters)
        {
            return parameters[PlayerIsAliveSensor.PlayerIsAliveParameter] && parameters[IsReturningSensor.IsReturningParameter];
        }

        public override void Execute()
        {
            transform.position = ship.InFlockPosition;
        }
    }
}