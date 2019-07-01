using Scripts.Controllers.InputController;

namespace Scripts.Player
{
    public class PlayerAttackController : AttackController
    {
        private BaseInputController inputController;

        protected override void Start()
        {
            base.Start();
            inputController = GetComponent<BaseInputController>();
        }

        void Update()
        {
            if (CanAttack())
                Attack();
        }

        public override bool CanAttack()
        {
            return base.CanAttack() && inputController.IsAttack();
        }
    }
}