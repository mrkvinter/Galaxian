using Engine;
using Engine.Events;
using UnityEngine;

namespace Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        public GameObject GameOverPanel;
        public GameObject WinPanel;

        private int countEnemy;
        private int countOfDeadEnemies;
        void Start()
        {
            countEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
            EventSystem.Instance.Subscribe<PlayerDied>(_ => GameOverPanel.SetActive(true));
            EventSystem.Instance.Subscribe<EnemyKilled>(_ =>
            {
                countOfDeadEnemies++;
                if (countOfDeadEnemies == countEnemy)
                    WinPanel.SetActive(true);
            });
        }
    }
}
