using System;
using BulletSmileTestProject.Architecture.Configs.MainCharacter.Scripts;
using BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts;
using TMPro;
using UnityEngine;
using Zenject;

namespace BulletSmileTestProject.UI.Prefabs.ScreenGameplay.Scripts
{
    public class MainCharacterHealthUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;

        private MainCharacter _mainCharacter;
        private MainCharacterConfig _config;
        
        [Inject]
        private void Construct(MainCharacter mainCharacter, MainCharacterConfig config)
        {
            _mainCharacter = mainCharacter;
            _config = config;
        }

        private void OnEnable()
        {
            _mainCharacter.Health.OnHealthChanged += HealthOnOnHealthChanged;
            UpdateText(_config.MaxHealth);
        }

        private void HealthOnOnHealthChanged(int currentHealth)
        {
            UpdateText(currentHealth);
        }

        private void UpdateText(int currenthealth)
        {
            if (currenthealth < 0)
                currenthealth = 0;
            
            string text = $"{currenthealth}/{_config.MaxHealth}";
            _healthText.text = text;
        }

        private void OnDisable()
        {
            _mainCharacter.Health.OnHealthChanged -= HealthOnOnHealthChanged;
        }
    }
}
