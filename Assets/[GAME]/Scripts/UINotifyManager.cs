using Engine;
using Engine.Events;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class UINotifyManager : MonoBehaviour
    {
        public GameObject ScoreUpNotifyObject;

        void Start()
        {
            EventSystem.Instance.Subscribe<ScoreUp>(e =>
            {
                var obj = Instantiate(ScoreUpNotifyObject, e.Position, Quaternion.identity);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = $"+{e.ScoreCount}";
            });
        }
    }
}