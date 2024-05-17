using UnityEngine;

namespace BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts.Interfaces
{
    public interface IInputHandler
    {
        public Vector2 JumpDirection { get; }
        void EnableInput();
        void DisableInput();
    }
}