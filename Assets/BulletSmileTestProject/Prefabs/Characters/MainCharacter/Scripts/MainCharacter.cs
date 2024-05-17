using System;
using BulletSmileTestProject.Architecture.Configs.MainCharacter.Scripts;
using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.Interfaces;
using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.States;
using BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Movement))]
    public class MainCharacter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private JumpArrowRenderer _arrowRenderer;

        private SphereCollider _collider;
        private Rigidbody _rigidbody;
        private Movement _movement;
        private IHealth _health;
        private ILevelService _levelService;
        private IInputHandler _inputHandler;
        private IGameStateMachine _gameStateMachine;

        public IHealth Health => _health; 
        
        [Inject]
        private void Construct(MainCharacterConfig config, IInputService inputService, ITimeService timeService, ILevelService levelService, IGameStateMachine gameStateMachine)
        {
            _levelService = levelService;
            _gameStateMachine = gameStateMachine;

            _collider = GetComponent<SphereCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            _movement = GetComponent<Movement>();

            _inputHandler = new InputHandler(config,this, _camera, inputService);
            _inputHandler.EnableInput();
            _health = new Health(config, gameStateMachine);
            
            _movement.Init(config, _rigidbody, _inputHandler, inputService, timeService);
            _arrowRenderer.Init(_inputHandler);
        }

        private void OnEnable()
        {
            _health.OnDied += EndGameState;
            
            //Does not work, no idea
            //_levelService.GetCurrentLevel().EndPoint.OnEndTriggered += EndGameState;
        }
        
        private void Start()
        {
            transform.position = _levelService.GetCurrentLevel().StartPoint.position;
        }

        public void EndGameState()
        {
            _inputHandler.DisableInput();
            
            _gameStateMachine.EnterIn<EndGameState>();
        }

        private void OnDisable()
        {
            _health.OnDied -= EndGameState;
            _levelService.GetCurrentLevel().EndPoint.OnEndTriggered -= EndGameState;
        }
    }
}
