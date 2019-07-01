using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.AI
{
    public class LocomotionFlock : MonoBehaviour
    {
        public float Speed;

        private List<Ship> flok;
        private Vector2 direction = Vector2.right;
        private BorderLimiter borderLimiter;

        void Start()
        {
            borderLimiter = GetComponent<BorderLimiter>();

            flok = new List<Ship>(transform.childCount);
            for (var i = 0; i < transform.childCount; i++)
            {
                var ship = transform.GetChild(i).GetComponent<Ship>();
                if (ship != null)
                    flok.Add(ship);
            }
        }

        void Update()
        {
            var changeDirection = false;
            flok = flok.Where(e => e != null).ToList();
            foreach (var bird in flok)
            {
                bird.InFlockPosition += Speed * Time.deltaTime * direction;

                if (!changeDirection &&
                    (direction.x < 0 && bird.InFlockPosition.x <= borderLimiter.BorderLeft ||
                     direction.x > 0 && bird.InFlockPosition.x >= borderLimiter.BorderRight))
                {
                    changeDirection = true;
                }
            }

            if (changeDirection)
                direction *= -1;
        }
    }
}