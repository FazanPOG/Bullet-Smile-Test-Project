using UnityEngine;

namespace BulletSmileTestProject.Architecture.Configs.MainCharacter.Scripts
{
    [CreateAssetMenu(menuName = "Configs/MainCharacter/Config")]
    public class MainCharacterConfig : ScriptableObject
    {
        [SerializeField, Range(1, 10)] private int _maxHealth = 3;
        [SerializeField, Range(1, 10)] private float _jumpForce;
        [SerializeField, Range(0.1f, 10f)] private float _slowDownTimeDuration;

        public int MaxHealth=> _maxHealth;
        public float JumpForce => _jumpForce;
        public float SlowDownTimeDuration => _slowDownTimeDuration;
    }
}
