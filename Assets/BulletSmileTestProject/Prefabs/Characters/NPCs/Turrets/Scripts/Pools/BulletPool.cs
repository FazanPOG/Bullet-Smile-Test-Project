using BulletSmileTestProject.Architecture.Configs.Turrets.Scripts;
using UnityEngine;
using UnityEngine.Pool;

namespace BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.Pools
{
    public class BulletPool
    {
        private ObjectPool<Bullet> _pool;
        private Bullet _prefab;
        
        public BulletPool(BulletPoolConfig config)
        {
            _prefab = config.BulletPrefab;
            
            _pool = new ObjectPool<Bullet>(Create, OnGet, OnRelease, OnDestroy, true, config.DefaultCapacity, config.MaxSize);
        }

        public Bullet Get()
        {
            return _pool.Get();
        }
        
        public void Release(Bullet bullet)
        {
            _pool.Release(bullet);
        }

        private Bullet Create()
        {
            return GameObject.Instantiate(_prefab);
        }
        
        private void OnGet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
        }
        
        private void OnRelease(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }
        
        private void OnDestroy(Bullet bullet)
        {
            GameObject.Destroy(bullet.gameObject);
        }
    }
}