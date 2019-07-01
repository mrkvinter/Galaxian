using DG.Tweening;
using UnityEngine;

namespace Scripts.Transformation
{
    public class SquashStretch : MonoBehaviour
    {
        public float TimeOfSquash;
        public float TimeOfStretch;
        public float TimeOfReturnToOriginal;
        public Vector3 ForceOfSquash = Vector3.one;
        public Vector3 ForceOfStretch = Vector3.one;
        public int RepeatOfEffectWithDampingCount = 3;

        private Vector3 originalScale;

        private void Awake()
        {
            originalScale = gameObject.transform.localScale;
        }

        private void OnEnable()
        {
            StartSquashStretch();
        }

        public void StartSquashStretch(float force = 1, int count = 0)
        {
            var endScaleOfSquash = new Vector3(originalScale.x + ForceOfSquash.x * force,
                originalScale.y + ForceOfSquash.y * force,
                originalScale.z + ForceOfSquash.z * force);

            var endScaleOfStretch = new Vector3(originalScale.x + ForceOfStretch.x * force,
                originalScale.y + ForceOfStretch.y * force,
                originalScale.z + ForceOfStretch.z * force);

            DOTween
                .To(() => gameObject.transform.localScale, s => gameObject.transform.localScale = s, endScaleOfSquash,
                    TimeOfSquash)
                .OnComplete(() =>

                {
                    var tween = DOTween.To(
                            () => gameObject.transform.localScale,
                            s => gameObject.transform.localScale = s,
                            endScaleOfStretch, TimeOfStretch)
                        .OnComplete(
                            () => DOTween.To(
                                () => gameObject.transform.localScale,
                                s => gameObject.transform.localScale = s,
                                originalScale, TimeOfReturnToOriginal));

                    if (count < RepeatOfEffectWithDampingCount)
                        tween.OnComplete(() => StartSquashStretch(force / 2, count + 1));
                });
        }
    }
}