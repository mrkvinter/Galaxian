using UnityEngine;

namespace Scripts.AI
{
    public class Ship : MonoBehaviour
    {
        [HideInInspector] public Vector2 InFlockPosition;

        void Start()
        {
            InFlockPosition = transform.position;
        }
    }
}