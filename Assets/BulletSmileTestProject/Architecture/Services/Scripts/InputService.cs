using System;
using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BulletSmileTestProject.Architecture.Services.Scripts
{
    public class InputService : IInputService
    {
        private readonly MainCharacterInputAction _mainCharacterInputAction;

        private Vector2 _movementVectorNormalized;
        private Vector2 _startPosition;
        private Vector2 _currentPosition;
        
        public Vector2 MouseScreenPosition { get; private set; }

        public event Action OnMouseDown;  
        public event Action OnMouseUp;  
        public event Action OnMouseMove;  

        public InputService()
        {
            _mainCharacterInputAction = new MainCharacterInputAction();
            
            _mainCharacterInputAction.Enable();
            
            _mainCharacterInputAction.MainCharacter.Click.started += MouseDown;
            _mainCharacterInputAction.MainCharacter.Click.canceled += MouseUp;
            _mainCharacterInputAction.MainCharacter.MousePosition.performed += MouseMove;
        }

        private void MouseMove(InputAction.CallbackContext context)
        {
            SetMousePosition();
            OnMouseMove?.Invoke();
        }

        private void MouseDown(InputAction.CallbackContext context)
        {
            SetMousePosition();
            OnMouseDown?.Invoke();
        }

        private void MouseUp(InputAction.CallbackContext context)
        {
            MouseScreenPosition = Vector2.zero;
            OnMouseUp?.Invoke();
        }

        private void SetMousePosition()
        {
            MouseScreenPosition = _mainCharacterInputAction.MainCharacter.MousePosition.ReadValue<Vector2>();
        }
    }
}