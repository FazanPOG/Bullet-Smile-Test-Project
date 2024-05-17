using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.States;
using UnityEngine;
using Zenject;

namespace BulletSmileTestProject.Architecture.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;
        
        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.EnterIn<BootState>();
        }
    }
}
