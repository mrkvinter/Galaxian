using Engine.Events;
using UnityEngine;
using EventSystem = Engine.EventSystem;

namespace Scripts
{
    public class ExplosionNotify : MonoBehaviour
    {
        void BlowUp()
        {
            EventSystem.Instance.Notify(new ExplosionEvent(gameObject, transform.position));
        }
    }
}