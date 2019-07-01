using System.Collections.Generic;
using UnityEngine;

namespace Scripts.AI.AI
{
    public abstract class BaseActionNode : MonoBehaviour
    {
        public BaseActionNode[] NextActions;

        public abstract bool IsCanStart(Dictionary<string, bool> parameters);

        public abstract void Execute();

        public BaseActionNode[] NextNodes => NextActions;
    }
}