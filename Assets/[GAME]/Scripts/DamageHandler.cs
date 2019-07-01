using Scripts.Managers;
using UnityEngine;

namespace Scripts
{
    public class DamageHandler : MonoBehaviour
    {
        public PoolManager.TypeObject DeathSpawnObject;


        public virtual void Die()
        {
            var go = PoolManager.Instance.InstantiatePoolObject(DeathSpawnObject);
            go.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}