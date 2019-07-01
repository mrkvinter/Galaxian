using Engine;
using Engine.Events;

namespace Scripts.Player
{
    public class PlayerDamageHandler : DamageHandler
    {
        public override void Die()
        {
            EventSystem.Instance.Notify(new PlayerDied(gameObject));
            base.Die();
        }
    }
}