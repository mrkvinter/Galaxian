using Scripts.Managers;
using UnityEngine;

namespace Scripts
{
    public class DestroyByAnimationTrigger : MonoBehaviour
    {
        public void Destroy()
        {
            PoolManager.Instance.DestroyPoolObject(PoolManager.TypeObject.Explosion, gameObject);
        }
    }
}