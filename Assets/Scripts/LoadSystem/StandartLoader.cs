using UnityEngine.SceneManagement;

namespace IceCream.LoadSystem
{
    public class StandartLoader : ILoader
    {
        public void Load(SceneData sceneData)
        {
            SceneManager.LoadSceneAsync(sceneData.name);
        }
    }
}
