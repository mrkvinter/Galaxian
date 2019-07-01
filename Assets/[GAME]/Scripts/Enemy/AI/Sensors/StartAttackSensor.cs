using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.AI.AI.Sensors
{
    public class StartAttackSensor : BaseSensor
    {
        public const string IsAttackParameter = "IsAttack";

        [Header("START ATTACK")] public float CheckFrequencyStartAttack;
        [Range(0, 1)] public float ProbabilityStartAttack;

        [Header("START SHOOT")] public float CheckFrequencyShoot;
        [Range(0, 1)] public float ProbabilityShoot;

        public bool IsShoot { get; private set; }
        private bool isAttack;

        private void Start()
        {
            StartCoroutine(CheckAttack());
            StartCoroutine(CheckShoot());
        }

        private IEnumerator CheckAttack()
        {
            while (true)
            {
                yield return new WaitForSeconds(CheckFrequencyStartAttack);
                isAttack = Random.value < ProbabilityStartAttack;
            }
        }

        private IEnumerator CheckShoot()
        {
            while (true)
            {
                yield return new WaitForSeconds(CheckFrequencyShoot);
                IsShoot = Random.value < ProbabilityShoot;
            }
        }

        public override (string key, bool value) CollectSensor()
        {
            return (IsAttackParameter, isAttack);
        }
    }
}