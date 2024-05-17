using System;
using BulletSmileTestProject.Architecture.Configs.MainCharacter.Scripts;
using BulletSmileTestProject.Architecture.StateMachines.GameStateMachine.Scripts.Interfaces;
using BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts.Interfaces;

namespace BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts
{
    public class Health : IHealth
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly int _maxHealth;

        private int _currentHealth;
        private bool _canTakeDamage = true;
        
        public event Action<int> OnHealthChanged;
        public event Action OnDied;

        public Health(MainCharacterConfig config, IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _maxHealth = config.MaxHealth;
            _currentHealth = _maxHealth;
        }
        
        public void TakeDamage(int damage)
        {
            if(_canTakeDamage == false) return;
            
            if(damage < 0)
                throw new ArgumentException("Damage must be more then 0");

            _currentHealth -= damage;
            OnHealthChanged?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                _canTakeDamage = false;
                OnDied?.Invoke();
            }
                
        }
    }
}