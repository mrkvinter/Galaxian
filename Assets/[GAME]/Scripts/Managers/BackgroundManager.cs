using Engine;

namespace Scripts.Managers
{
    public class BackgroundManager : Singleton<BackgroundManager>
    {
        public override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
