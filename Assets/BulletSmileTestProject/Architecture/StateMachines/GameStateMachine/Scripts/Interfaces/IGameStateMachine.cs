using System;

namespace BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.Interfaces
{
    public interface IGameStateMachine
    {
        void EnterIn<T>() where T : IGameState;
    }
}