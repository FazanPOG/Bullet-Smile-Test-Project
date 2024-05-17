using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts;
using UnityEngine;

namespace BulletSmileTestProject.Architecture.Configs.Turrets.Scripts
{
    [CreateAssetMenu(menuName = "Configs/Turrets/TurretsPrefabReferences")]
    public class TurretsPrefabReferences : ScriptableObject
    {
        [SerializeField] private BaseTurret _bulletTurret;
        [SerializeField] private BaseTurret _laserTurret;

        public BaseTurret BulletTurret => _bulletTurret;
        public BaseTurret LaserTurret => _laserTurret;
    }
}