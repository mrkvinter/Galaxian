using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Scripts.DotweenAnimations
{
    public class DisappearsTextTween : MonoBehaviour
    {
        public float Duration;

        void Start()
        {
            var text = GetComponent<TextMeshProUGUI>();

            text.DOColor(new Color(text.color.r, text.color.g, text.color.b, 0), Duration);
        }
    }
}