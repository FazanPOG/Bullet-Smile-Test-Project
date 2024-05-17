using BulletSmileTestProject.Architecture.Configs.Turrets.Scripts;
using BulletSmileTestProject.Architecture.Factories.TurretsFactory.Scripts.Interfaces;
using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts;
using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.Enums;
using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.Interfaces;
using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.TurretShooters;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace BulletSmileTestProject.Architecture.Factories.TurretsFactory.Scripts
{
    public class TurretFactory : ITurretFactory
    {
        private readonly DiContainer _diContainer;
        private readonly BulletPoolConfig _bulletPoolConfig;
        private readonly TurretsPrefabReferences _turretsPrefabReferences;

        public TurretFactory(DiContainer diContainer, BulletPoolConfig bulletPoolConfig, TurretsPrefabReferences turretsPrefabReferences)
        {
            _diContainer = diContainer;
            _bulletPoolConfig = bulletPoolConfig;
            _turretsPrefabReferences = turretsPrefabReferences;
        }
        
        public void Create(TurretType type, Vector3 position)
        {
            switch (type)
            {
                case TurretType.Bullet:
                    BaseTurret bulletTurret = _diContainer.InstantiatePrefabForComponent<BaseTurret>(_turretsPrefabReferences.BulletTurret);
                    
                    ITurretShooter bulletShooter = new BulletTurretShooter(_bulletPoolConfig, (BulletTurret)bulletTurret);
                    bulletTurret.Init(bulletShooter);
                    
                    bulletTurret.transform.position = position;
                    break;
                
                case TurretType.Laser:
                    BaseTurret laserTurret = _diContainer.InstantiatePrefabForComponent<BaseTurret>(_turretsPrefabReferences.LaserTurret);

                    LaserTurretShooter laserTurretShooter;
                    if (laserTurret.TryGetComponent(out LaserTurretShooter shooter))
                        laserTurretShooter = shooter;
                    else
                        laserTurretShooter = laserTurret.AddComponent<LaserTurretShooter>();
                    
                    laserTurretShooter.Init(laserTurret.Config);
                    laserTurret.Init(laserTurretShooter);
                    
                    laserTurret.transform.position = position;
                    break;
            }
        }
    }
}