using System.Collections.Generic;
using System.Linq;
using Scripts.AI.AI.Sensors;
using UnityEngine;

namespace Scripts.AI.AI
{
    public class AISystem : MonoBehaviour
    {
        public BaseActionNode StartNode;

        private BaseActionNode currentNode;
        private BaseSensor[] sensors;

        private void Start()
        {
            sensors = GetComponents(typeof(BaseSensor)).Select(e => (BaseSensor) e).ToArray();

            currentNode = StartNode;
        }

        void Update()
        {
            var parameters = CollectParametrs();

            currentNode = currentNode.NextNodes.FirstOrDefault(e => e.IsCanStart(parameters)) ?? currentNode;

            currentNode.Execute();
        }

        private Dictionary<string, bool> CollectParametrs()
        {
            var parameters = new Dictionary<string, bool>();

            for (var i = 0; i < sensors.Length; i++)
            {
                var parameter = sensors[i].CollectSensor();
                parameters.Add(parameter.key, parameter.value);
            }

            return parameters;
        }
    }
}