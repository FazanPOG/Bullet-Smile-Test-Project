using BulletSmileTestProject.Architecture.Factories.LevelFactory.Scripts;
using BulletSmileTestProject.Architecture.Factories.LevelFactory.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.Factories.TurretsFactory.Scripts;
using BulletSmileTestProject.Architecture.Factories.TurretsFactory.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.Services.Scripts;
using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts;
using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.Interfaces;
using BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts;
using BulletSmileTestProject.UI.Prefabs.ScreenGameplay.Scripts;
using UnityEngine;
using Zenject;

namespace BulletSmileTestProject.Architecture.Zenject.Scripts
{
    public class BootSceneInstaller : MonoInstaller
    {
        [SerializeField] private MainCharacter _mainCharacterPrefab;
        [Header("UI")]
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private GameInfoUI _gameInfoUIPrefab;
        [SerializeField] private MainCharacterHealthUI _mainCharacterHealthUIPrefab;
        
        public override void InstallBindings()
        {
            BindFactories();
            BindServices();
            BindGameInfoUI();
            BindGameStateMachine();
            BindMainCharacter();
            BindMainCharacterInfoUI();
        }

        private void BindFactories()
        {
            BindTurretsFactory();
            BindLevelFactory();
        }
        
        private void BindServices()
        {
            BindLevelService();
        }

        private void BindMainCharacter()
        {
            var mainCharacter = Container.InstantiatePrefabForComponent<MainCharacter>(_mainCharacterPrefab);
            Container
                .Bind<MainCharacter>()
                .FromInstance(mainCharacter)
                .AsSingle();
        }
        
        private void BindGameStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .FromNew()
                .AsSingle();
        }
        
        private void BindGameInfoUI()
        {
            var instance = Container.InstantiatePrefabForComponent<GameInfoUI>(_gameInfoUIPrefab, _mainCanvas.transform);
            
            Container
                .Bind<GameInfoUI>()
                .FromInstance(instance)
                .AsSingle();
        }
        
        private void BindMainCharacterInfoUI()
        {
            var instance = Container.InstantiatePrefabForComponent<MainCharacterHealthUI>(_mainCharacterHealthUIPrefab, _mainCanvas.transform);
            
            Container
                .Bind<MainCharacterHealthUI>()
                .FromInstance(instance)
                .AsSingle();
        }
        
        private void BindTurretsFactory()
        {
            Container
                .Bind<ITurretFactory>()
                .To<TurretFactory>()
                .FromNew()
                .AsSingle();
        }
        
        private void BindLevelFactory()
        {
            Container
                .Bind<ILevelFactory>()
                .To<LevelFactory>()
                .FromNew()
                .AsSingle();
        }
        
        private void BindLevelService()
        {
            Container
                .Bind<ILevelService>()
                .To<LevelService>()
                .FromNew()
                .AsSingle();
        }

    }
}
