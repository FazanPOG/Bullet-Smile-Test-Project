using BulletSmileTestProject.Architecture.Configs.Turrets.Scripts;
using Zenject;

namespace BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts
{
    public class BulletTurret : BaseTurret
    {
        private BulletPoolConfig _poolConfig;
        
        [Inject]
        private void Construct(BulletPoolConfig poolConfig)
        {
            _poolConfig = poolConfig;
        }
    }
}