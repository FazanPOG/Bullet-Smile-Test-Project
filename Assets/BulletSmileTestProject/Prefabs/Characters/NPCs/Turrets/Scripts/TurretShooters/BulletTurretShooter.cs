using System.Collections;
using BulletSmileTestProject.Architecture.Configs.Turrets.Scripts;
using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.Interfaces;
using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.Pools;
using UnityEngine;

namespace BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.TurretShooters
{
    public class BulletTurretShooter : ITurretShooter
    {
        private readonly Transform _bulletSpawnPoint;

        private BulletPool _pool;
        private TurretConfig _turretConfig;
        private bool _isCoroutineRunning;

        public BulletTurretShooter(BulletPoolConfig config, BulletTurret bulletTurret)
        {
            _turretConfig = bulletTurret.Config;
            _bulletSpawnPoint = bulletTurret.AmmoSpawnPoint;

            _pool = new BulletPool(config);
        }
        
        public void Shoot(MainCharacter.Scripts.MainCharacter target)
        {
            SpawnBullet(target.transform);
        }

        private void ReleaseBullet(Bullet bullet)
        {
            _pool.Release(bullet);
        }

        private void SpawnBullet(Transform lookAt)
        {
            Bullet bullet = _pool.Get();
            var transform = bullet.transform;
            transform.position = _bulletSpawnPoint.transform.position;
            transform.LookAt(lookAt.position);
            bullet.Init(_turretConfig.Damage, ReleaseBullet);
        }
    }
}