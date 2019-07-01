using UnityEngine;

namespace Scripts
{
    public class BorderLimiter : MonoBehaviour
    {
        public float BorderLeft;
        public float BorderRight;

        private Vector2 originalPosition;

        private void Start()
        {
            originalPosition = transform.position;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            var positionY = transform.position.y;
            Gizmos.DrawRay(new Vector3(originalPosition.x + BorderLeft, positionY, 0), new Vector3(0, 1, 0));
            Gizmos.DrawRay(new Vector3(originalPosition.x + BorderLeft, positionY, 0), new Vector3(0, -1, 0));

            Gizmos.DrawRay(new Vector3(originalPosition.x + BorderRight, positionY, 0), new Vector3(0, 1, 0));
            Gizmos.DrawRay(new Vector3(originalPosition.x + BorderRight, positionY, 0), new Vector3(0, -1, 0));
        }
    }
}