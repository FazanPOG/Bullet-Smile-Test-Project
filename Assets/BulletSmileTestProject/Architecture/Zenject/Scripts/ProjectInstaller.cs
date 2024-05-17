using BulletSmileTestProject.Architecture.Configs.Level.Scripts;
using BulletSmileTestProject.Architecture.Configs.MainCharacter.Scripts;
using BulletSmileTestProject.Architecture.Configs.Turrets.Scripts;
using BulletSmileTestProject.Architecture.Services.Scripts;
using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using  UnityEngine;
using Zenject;

namespace BulletSmileTestProject.Architecture.Zenject.Scripts
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private MonoBehaviour _coroutineContext;
        [Header("Configs")]
        [SerializeField] private LevelReferencesSO _levelReferences;
        [SerializeField] private MainCharacterConfig _mainCharacterConfig;
        [SerializeField] private BulletPoolConfig _bulletPoolConfig;
        [SerializeField] private TurretsPrefabReferences _turretsPrefabReferences;
        
        public override void InstallBindings()
        {
            BindConfigs();
            BindServices();
            BindCoroutineContext();
        }
        
        private void BindConfigs()
        {
            BindLevelConfig();
            BindMainCharacterConfig();
            BindBulletPoolConfig();
            BindTurretsPrefabReferences();
        }

        private void BindLevelConfig()
        {
            Container
                .Bind<LevelReferencesSO>()
                .FromInstance(_levelReferences)
                .AsSingle();
        }
        
        private void BindMainCharacterConfig()
        {
            Container
                .Bind<MainCharacterConfig>()
                .FromInstance(_mainCharacterConfig)
                .AsSingle();
        }

        private void BindBulletPoolConfig()
        {
            Container
                .Bind<BulletPoolConfig>()
                .FromInstance(_bulletPoolConfig)
                .AsSingle();
        }

        private void BindTurretsPrefabReferences()
        {
            Container
                .Bind<TurretsPrefabReferences>()
                .FromInstance(_turretsPrefabReferences)
                .AsSingle();
        }

        private void BindServices()
        {
            BindInputService();
            BindTimeService();
            BindSceneLoaderService();
        }
        
        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<InputService>()
                .FromNew()
                .AsSingle();
        }

        private void BindTimeService()
        {
            Container
                .Bind<ITimeService>()
                .To<TimeService>()
                .FromNew()
                .AsSingle();
        }
        
        private void BindSceneLoaderService()
        {
            Container
                .Bind<ISceneLoaderService>()
                .To<SceneLoaderService>()
                .FromNew()
                .AsSingle();
        }
        
        private void BindCoroutineContext()
        {
            var instance = Container.InstantiatePrefabForComponent<MonoBehaviour>(_coroutineContext);

            Container
                .Bind<MonoBehaviour>()
                .FromInstance(instance)
                .AsSingle();
        }
    }
}