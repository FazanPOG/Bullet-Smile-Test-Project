using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts;
using UnityEngine;

namespace BulletSmileTestProject.Architecture.Configs.Turrets.Scripts
{
    [CreateAssetMenu(menuName = "Configs/Turrets/BulletPoolConfig")]
    public class BulletPoolConfig : ScriptableObject
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField, Range(1, 20)] private int _defaultCapacity;
        [SerializeField, Range(10, 100)] private int _maxSize;

        public Bullet BulletPrefab => _bulletPrefab;
        public int DefaultCapacity => _defaultCapacity;
        public int MaxSize => _maxSize;

        private void OnValidate()
        {
            if (_maxSize < _defaultCapacity)
                _maxSize = _defaultCapacity;
        }
    }
}