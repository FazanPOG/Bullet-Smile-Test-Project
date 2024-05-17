using System;

namespace BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts.Interfaces
{
    public interface IHealth
    {
        void TakeDamage(int damage);

        event Action<int> OnHealthChanged;
        event Action OnDied;
    }
}