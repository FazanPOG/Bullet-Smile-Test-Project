using BulletSmileTestProject.Architecture.Configs.MainCharacter.Scripts;
using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts.Interfaces;
using UnityEngine;

namespace BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts
{
    public class Movement : MonoBehaviour
    {
        private MainCharacterConfig _config;
        private Rigidbody _rigidbody;
        private IInputHandler _inputHandler;
        private IInputService _inputService;
        private ITimeService _timeService;
        
        public void Init(MainCharacterConfig config, Rigidbody rigidbody, IInputHandler inputHandler, IInputService inputService, ITimeService timeService)
        {
            _config = config;
            _rigidbody = rigidbody;
            _inputHandler = inputHandler;
            _inputService = inputService;
            _timeService = timeService;

            _inputService.OnMouseDown += _timeService.SlowDownTime;
            _inputService.OnMouseUp += Jump;
            _inputService.OnMouseUp += _timeService.SpeedUpTime;
        }

        private void Jump()
        {
            float jumpForce = _config.JumpForce;
            Vector3 forceDirection = new Vector3(_inputHandler.JumpDirection.x, _inputHandler.JumpDirection.y, 0f);
            _rigidbody.AddForce(forceDirection * jumpForce, ForceMode.Impulse);
        }

        private void OnDisable()
        {
            _inputService.OnMouseDown -= _timeService.SlowDownTime;
            _inputService.OnMouseUp -= Jump;
            _inputService.OnMouseUp -= _timeService.SpeedUpTime;
        }
    }
}