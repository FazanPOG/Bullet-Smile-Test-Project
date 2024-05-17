using BulletSmileTestProject.Architecture.Configs.Level.Scripts;
using BulletSmileTestProject.Architecture.Factories.LevelFactory.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.Factories.TurretsFactory.Scripts.Interfaces;
using BulletSmileTestProject.Prefabs.Levels.Scripts;
using Zenject;

namespace BulletSmileTestProject.Architecture.Factories.LevelFactory.Scripts
{
    public class LevelFactory : ILevelFactory
    {
        private readonly DiContainer _diContainer;
        private readonly ITurretFactory _turretFactory;
        private readonly LevelReferencesSO _levelReferencesSo;
        
        public LevelFactory(DiContainer diContainer, ITurretFactory turretFactory)
        {
            _diContainer = diContainer;
            _turretFactory = turretFactory;
        }
        
        public void Create(Level level)
        {
            _diContainer.InstantiatePrefab(level);
            
            foreach (var spawnPoint in level.TurretsSpawnPoints)
                _turretFactory.Create(spawnPoint.Type, spawnPoint.transform.position);
        }
    }
}