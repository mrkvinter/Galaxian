using DG.Tweening;
using UnityEngine;

namespace Scripts.DotweenAnimations
{
    public class UpTween : MonoBehaviour
    {
        public float Delay;
        public float HeightUp;
        public bool KillOnComplete;

        private void Start()
        {
            var tween = transform.DOLocalMoveY(transform.localPosition.y + HeightUp, Delay);

            if (KillOnComplete)
                tween.onComplete += () => Destroy(gameObject);
        }
    }
}