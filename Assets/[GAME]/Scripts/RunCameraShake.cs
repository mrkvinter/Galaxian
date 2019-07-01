using Cinemachine;
using Engine;
using Engine.Events;
using UnityEngine;

namespace Scripts
{
    public class RunCameraShake : MonoBehaviour
    {
        private CinemachineImpulseSource impulseSource;

        void Start()
        {
            impulseSource = GetComponent<CinemachineImpulseSource>();
            EventSystem.Instance.Subscribe<ExplosionEvent>(e =>
            {
                if (impulseSource != null) impulseSource.GenerateImpulse(e.Position);
            });
        }
    }
}