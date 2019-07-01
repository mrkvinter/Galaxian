using UnityEngine;

namespace Scripts.Controllers.InputController
{
    public class TouchInputController : BaseInputController
    {
        public override float GetHorizontalDirection(Vector2 currentPosition)
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                Debug.Log(touch.position);
                var worldPositionTouch = Camera.main.ScreenToWorldPoint(touch.position);

                var direction = worldPositionTouch.x - transform.position.x;
                return Mathf.Clamp(direction, -1, 1);
            }

            return 0;
        }

        public override bool IsAttack()
        {
            return Input.touchCount > 0;
        }
    }
}