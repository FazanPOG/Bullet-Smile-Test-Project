using System;
using System.Collections.Generic;
using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.States;
using BulletSmileTestProject.UI.Prefabs.ScreenGameplay.Scripts;
using UnityEngine;
using Zenject;

namespace BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IGameState> _states;
        
        private IGameState _currentState;

        [Inject]
        public GameStateMachine(ILevelService levelService, GameInfoUI gameInfoUI, IInputService inputService, ISceneLoaderService sceneLoaderService)
        {
            _states = new Dictionary<Type, IGameState>()
            {
                [typeof(BootState)] = new BootState(levelService, this, gameInfoUI),
                [typeof(GameState)] = new GameState(),
                [typeof(EndGameState)] = new EndGameState(gameInfoUI, inputService, sceneLoaderService),
            };
        }

        public void EnterIn<T>() where T : IGameState
        {
            if (_states.TryGetValue(typeof(T), out IGameState state) == false)
                throw new MissingComponentException($"Missing game state type of {typeof(T)}");
            
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}