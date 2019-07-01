using Engine;
using Engine.Events;
using Scripts.Transformation;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class ScoreTextController : MonoBehaviour
    {
        public ScoreController ScoreController;

        private TextMeshProUGUI textMeshProUgui;

        private SquashStretch squashStretch;

        void Start()
        {
            textMeshProUgui = GetComponent<TextMeshProUGUI>();
            squashStretch = GetComponent<SquashStretch>();

            EventSystem.Instance.Subscribe<ScoreUp>(args =>
            {
                textMeshProUgui.text = ScoreController.Score.ToString();
                squashStretch.StartSquashStretch();
            });
        }
    }
}