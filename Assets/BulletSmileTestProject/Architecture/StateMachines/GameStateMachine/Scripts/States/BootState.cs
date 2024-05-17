using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.Interfaces;
using BulletSmileTestProject.UI.Prefabs.ScreenGameplay.Scripts;

namespace BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.States
{
    public class BootState : IGameState
    {
        private readonly ILevelService _levelService;
        private readonly GameStateMachine _gameStateMachine;
        private readonly GameInfoUI _gameInfoUI;

        public BootState(ILevelService levelService, GameStateMachine gameStateMachine, GameInfoUI gameInfoUI)
        {
            _levelService = levelService;
            _gameStateMachine = gameStateMachine;
            _gameInfoUI = gameInfoUI;
        }
        
        public void Enter()
        {
            _levelService.LoadLevel();
            _gameInfoUI.StartGameInfo();
            
            _gameStateMachine.EnterIn<GameState>();
        }

        public void Exit()
        {
            
        }
    }
}