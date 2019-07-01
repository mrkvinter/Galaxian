using Engine;
using Engine.Events;

namespace Scripts
{
    public class EnemyDamageHandler : DamageHandler
    {
        private ScoreCost scoreCost;

        private void Start()
        {
            scoreCost = GetComponent<ScoreCost>();
        }

        public override void Die()
        {
            EventSystem.Instance.Notify(new EnemyKilled(gameObject, scoreCost.ScoreCostCount));

            base.Die();
        }
    }
}