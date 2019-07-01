using UnityEngine;

namespace Scripts.Controllers.InputController
{
    public abstract class BaseInputController : MonoBehaviour
    {
        public abstract float GetHorizontalDirection(Vector2 currentPosition);
        public abstract bool IsAttack();
    }
}