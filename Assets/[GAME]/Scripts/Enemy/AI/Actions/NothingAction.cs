using System.Collections.Generic;
using Scripts.AI.AI.Sensors;

namespace Scripts.AI.AI.Actions
{
    public class NothingAction : BaseActionNode
    {
        public override bool IsCanStart(Dictionary<string, bool> parameters)
        {
            return !parameters[PlayerIsAliveSensor.PlayerIsAliveParameter] &&
                   parameters[IsReturningSensor.IsReturningParameter];
        }

        public override void Execute()
        {
        }
    }
}