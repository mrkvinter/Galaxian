using UnityEngine;

namespace Scripts.Controllers.InputController
{
    public class KeyboardInputController : BaseInputController
    {
        public override float GetHorizontalDirection(Vector2 currentPosition)
        {
            return Input.GetAxis("Horizontal");
        }

        public override bool IsAttack()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}