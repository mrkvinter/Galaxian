using System.Collections;
using Scripts.Managers;
using UnityEngine;

namespace Scripts
{
    public class Projectile : MonoBehaviour
    {
        public PoolManager.TypeObject TypeBullet;
        public float Speed;
        public Vector3 Direction;
        public LayerMask Target;
        public float TimeOfLife;

        private Coroutine coroutineTimer;

        private void OnEnable()
        {
            coroutineTimer = StartCoroutine(TimerOfLife());
        }

        private void FixedUpdate()
        {
            transform.position += Direction * Speed;
        }

        private IEnumerator TimerOfLife()
        {
            var timer = .0f;
            while (timer < TimeOfLife)
            {
                yield return new WaitForFixedUpdate();
                timer += Time.fixedDeltaTime;
            }

            PoolManager.Instance.DestroyPoolObject(TypeBullet, gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Target != (Target | (1 << other.gameObject.layer)))
                return;

            var damageHandler = other.GetComponent<DamageHandler>();
            if (damageHandler != null)
            {
                damageHandler.Die();
                StopCoroutine(coroutineTimer);
                PoolManager.Instance.DestroyPoolObject(TypeBullet, gameObject);
            }
        }
    }
}