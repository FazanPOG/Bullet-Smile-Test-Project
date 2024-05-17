using BulletSmileTestProject.Architecture.Configs.Level.Scripts;
using BulletSmileTestProject.Architecture.Factories.LevelFactory.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using BulletSmileTestProject.Prefabs.Levels.Scripts;
using Zenject;

namespace BulletSmileTestProject.Architecture.Services.Scripts
{
    public class LevelService : ILevelService
    {
        private readonly ILevelFactory _levelFactory;
        private readonly LevelReferencesSO _levelReferencesSo;

        private int _currentLevelIndex;
        
        [Inject]
        public LevelService(ILevelFactory levelFactory, LevelReferencesSO levelReferencesSo)
        {
            _levelFactory = levelFactory;
            _levelReferencesSo = levelReferencesSo;

            _currentLevelIndex = 0;
        }

        public void LoadLevel()
        {
            _levelFactory.Create(GetCurrentLevel());
        }

        public Level GetCurrentLevel()
        {
            return _levelReferencesSo.Levels[_currentLevelIndex];
        }
    }
}