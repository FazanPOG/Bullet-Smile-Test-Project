using UnityEngine;

namespace BulletSmileTestProject.Architecture.Configs.Turrets.Scripts
{
    [CreateAssetMenu(menuName = "Configs/Enemies/TurretConfig")]
    public class TurretConfig : ScriptableObject
    {
        [SerializeField, Range(1f, 10f)] private float _attackRange;
        [SerializeField, Range(0.5f, 5f)] private float _attackDelay;
        [SerializeField, Range(0, 10)] private int _damage;

        public float AttackRange => _attackRange;
        public float AttackDelay => _attackDelay;
        public int Damage => _damage;
    }
}