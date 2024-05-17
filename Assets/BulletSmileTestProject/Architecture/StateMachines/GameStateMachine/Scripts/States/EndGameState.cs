using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.Interfaces;
using BulletSmileTestProject.UI.Prefabs.ScreenGameplay.Scripts;

namespace BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.States
{
    public class EndGameState : IGameState
    {
        private readonly GameInfoUI _gameInfoUI;
        private readonly IInputService _inputService;
        private readonly ISceneLoaderService _sceneLoaderService;

        public EndGameState(GameInfoUI gameInfoUI, IInputService inputService, ISceneLoaderService sceneLoaderService)
        {
            _gameInfoUI = gameInfoUI;
            _inputService = inputService;
            _sceneLoaderService = sceneLoaderService;
        }
        
        public void Enter()
        {
            _gameInfoUI.EndGameInfo();
            _inputService.OnMouseDown += ReloadScene;
        }

        private void ReloadScene()
        {
            _inputService.OnMouseDown -= ReloadScene;
            _sceneLoaderService.ReloadCurrentScene();
        }

        public void Exit()
        {
            
        }
    }
}