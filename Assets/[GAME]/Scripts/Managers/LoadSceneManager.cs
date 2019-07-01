using Engine;
using UnityEngine.SceneManagement;

namespace Scripts.Managers
{
    public class LoadSceneManager : Singleton<LoadSceneManager>
    {
        public void LoadNext()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
        public void Restart()
        {
            SceneManager.LoadScene(1);
        }

        public void Quit()
        {
            SceneManager.LoadScene(0);
        }
    }
}
