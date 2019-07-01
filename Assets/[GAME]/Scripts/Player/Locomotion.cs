using Scripts.Controllers.InputController;
using UnityEngine;

namespace Scripts.Player
{
    public class Locomotion : MonoBehaviour
    {
        public float Speed;

        private BorderLimiter borderLimiter;
        private BaseInputController inputController;
        private Vector2 originalPosition;

        private void Start()
        {
            borderLimiter = GetComponent<BorderLimiter>();
            inputController = GetComponent<BaseInputController>();
            originalPosition = transform.position;

            Debug.Assert(inputController);
        }

        void Update()
        {
            var axisHorizontal = inputController.GetHorizontalDirection(transform.position);

            var transformPosition = (Vector2) transform.position;

            if (axisHorizontal < 0 && transformPosition.x >= originalPosition.x + borderLimiter.BorderLeft ||
                axisHorizontal > 0 && transformPosition.x <= originalPosition.x + borderLimiter.BorderRight)
            {
                transformPosition += axisHorizontal * Speed * Time.deltaTime * Vector2.right;

                transform.position = transformPosition;
            }
        }
    }
}