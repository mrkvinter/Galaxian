using System.Collections.Generic;
using Scripts.AI.AI.Sensors;
using UnityEngine;

namespace Scripts.AI.AI.Actions
{
    public class AttackAction : BaseActionNode
    {
        public float Speed;
        public float ForwardSpeed;
        public BorderLimiter BorderLimiter;

        private Vector3 direction;
        private AttackController attackController;
        private StartAttackSensor startAttackSensor;

        private void Start()
        {
            attackController = GetComponent<AttackController>();
            startAttackSensor = GetComponent<StartAttackSensor>();

            direction = transform.position.x > 0 ? Vector3.left : Vector3.right;
        }

        public override bool IsCanStart(Dictionary<string, bool> parameters)
        {
            return parameters[StartAttackSensor.IsAttackParameter];
        }

        public override void Execute()
        {
            if (attackController != null && attackController.CanAttack() && startAttackSensor.IsShoot)
                attackController.Attack();

            transform.position += 2 * Speed * Time.deltaTime * direction +
                                  ForwardSpeed * Time.deltaTime * Vector3.down;

            if (
                (direction.x < 0 && transform.position.x <= BorderLimiter.BorderLeft ||
                 direction.x > 0 && transform.position.x >= BorderLimiter.BorderRight))
            {
                direction *= -1;
            }
        }
    }
}