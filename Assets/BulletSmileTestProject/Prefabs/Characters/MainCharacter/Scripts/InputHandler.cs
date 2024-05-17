using System;
using BulletSmileTestProject.Architecture.Configs.MainCharacter.Scripts;
using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts.Interfaces;
using UnityEngine;

namespace BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts
{
    public class InputHandler : IInputHandler, IDisposable
    {
        private readonly MainCharacterConfig _config;
        private readonly MainCharacter _mainCharacter;
        private readonly Camera _camera;
        private readonly IInputService _inputService;
        
        private bool _isEnabled;
        private bool _isDragging;

        public Vector2 JumpDirection { get; private set; }

        public InputHandler(MainCharacterConfig config, MainCharacter mainCharacter, Camera camera, IInputService inputService)
        {
            _config = config;
            _mainCharacter = mainCharacter;
            _camera = camera;
            _inputService = inputService;

            EnableInput();
            
            _inputService.OnMouseDown += OnMouseDown;
            _inputService.OnMouseUp += OnMouseUp;
            _inputService.OnMouseMove += OnMouseMove;
        }

        public void EnableInput() => _isEnabled = true;

        public void DisableInput() => _isEnabled = false;

        private void OnMouseDown()
        {
            JumpDirection = Vector2.zero;
            _isDragging = true;
        }

        private void OnMouseUp()
        {
            _isDragging = false;
        }

        private void OnMouseMove()
        {
            if (!_isDragging) return;
            if(!_isEnabled) return;
            
            Vector2 currentPosition = _inputService.MouseScreenPosition;
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            
            Vector2 normalizedScreenPosition = new Vector2(
                currentPosition.x / screenWidth,
                currentPosition.y / screenHeight
            );
            Vector2 normalizedPosition = new Vector2(
                (normalizedScreenPosition.x - 0.5f) * 2.0f,
                (normalizedScreenPosition.y - 0.5f) * 2.0f
            );
            
            JumpDirection = normalizedPosition.normalized;
        }
        
        public void Dispose()
        {
            _inputService.OnMouseDown -= OnMouseDown;
            _inputService.OnMouseUp -= OnMouseUp;
            _inputService.OnMouseMove -= OnMouseMove;
        }
    }
}