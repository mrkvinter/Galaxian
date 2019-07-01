using System.Collections.Generic;
using Scripts.AI.AI;
using Scripts.AI.AI.Sensors;
using UnityEngine;

namespace Scripts.AI
{
    public class TeleportAction : BaseActionNode
    {
        public Transform TeleportPosition;


        public override bool IsCanStart(Dictionary<string, bool> parameters)
        {
            return parameters[OutOfScreenSensor.IsOutOfScreenParameter];
        }

        public override void Execute()
        {
            transform.position = TeleportPosition.position;
        }
    }
}