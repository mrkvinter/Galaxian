using System.Collections;
using Scripts.Managers;
using UnityEngine;

namespace Scripts
{
    public class AttackController : MonoBehaviour
    {
        public PoolManager.TypeObject Bullet;
        public float ReloadDuration;
        public AudioClip ShootAudioClip;

        private bool isReloading;
        private AudioSource audioSource;

        protected virtual void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void Attack()
        {
            audioSource.PlayOneShot(ShootAudioClip);

            isReloading = true;
            StartCoroutine(ReloadAttack());

            var bullet = PoolManager.Instance.InstantiatePoolObject(Bullet);
            bullet.transform.position = transform.position;
        }

        public virtual bool CanAttack()
        {
            return !isReloading;
        }

        IEnumerator ReloadAttack()
        {
            yield return new WaitForSeconds(ReloadDuration);
            isReloading = false;
        }
    }
}