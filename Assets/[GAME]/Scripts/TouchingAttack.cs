using UnityEngine;

namespace Scripts
{
    public class TouchingAttack : MonoBehaviour
    {
        public LayerMask Target;

        private DamageHandler damageHandler;

        private void Start()
        {
            damageHandler = GetComponent<DamageHandler>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Target != (Target | (1 << other.gameObject.layer)))
                return;

            var otherDamageHandler = other.transform.GetComponent<DamageHandler>();
            if (otherDamageHandler != null)
            {
                otherDamageHandler.Die();
                damageHandler.Die();
            }
        }
    }
}