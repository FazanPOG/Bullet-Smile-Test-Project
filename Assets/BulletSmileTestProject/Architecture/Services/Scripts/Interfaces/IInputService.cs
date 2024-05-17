using System;
using UnityEngine;

namespace BulletSmileTestProject.Architecture.Services.Scripts.Interfaces
{
    public interface IInputService
    {
        public Vector2 MouseScreenPosition { get; }

        public event Action OnMouseDown;  
        public event Action OnMouseUp;  
        public event Action OnMouseMove; 
    }
}