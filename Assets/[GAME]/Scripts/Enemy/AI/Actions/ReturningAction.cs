using System.Collections.Generic;
using UnityEngine;

namespace Scripts.AI.AI.Actions
{
    public class ReturningAction : BaseActionNode
    {
        public float Speed;

        private Ship ship;

        private void Start()
        {
            ship = GetComponent<Ship>();
        }

        public override bool IsCanStart(Dictionary<string, bool> parameters)
        {
            return true;
        }

        public override void Execute()
        {
            transform.position += Speed * Time.deltaTime *
                                  ((Vector3) ship.InFlockPosition - transform.position).normalized;
        }
    }
}