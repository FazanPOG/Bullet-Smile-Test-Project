using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using UnityEngine.SceneManagement;

namespace BulletSmileTestProject.Architecture.Services.Scripts
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}