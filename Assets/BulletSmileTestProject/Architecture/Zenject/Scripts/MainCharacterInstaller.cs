using BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts;
using UnityEngine;
using Zenject;

namespace BulletSmileTestProject.Architecture.Zenject.Scripts
{
    public class MainCharacterInstaller : MonoInstaller
    {
        [SerializeField] private MainCharacter _mainCharacterPrefab;

        public override void InstallBindings()
        {
            BindMainCharacter();
        }

        private void BindMainCharacter()
        {
            var mainCharacter = Container.InstantiatePrefabForComponent<MainCharacter>(_mainCharacterPrefab);
            Container
                .Bind<MainCharacter>()
                .FromInstance(mainCharacter)
                .AsSingle()
                .NonLazy();
        }
    }
}