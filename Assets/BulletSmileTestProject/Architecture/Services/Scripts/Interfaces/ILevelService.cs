using BulletSmileTestProject.Prefabs.Levels.Scripts;

namespace BulletSmileTestProject.Architecture.Services.Scripts.Interfaces
{
    public interface ILevelService
    {
        void LoadLevel();
        Level GetCurrentLevel();
    }
}