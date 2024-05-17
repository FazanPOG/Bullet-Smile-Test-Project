using System.Collections;
using BulletSmileTestProject.Architecture.Configs.Turrets.Scripts;
using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.Interfaces;
using UnityEngine;

namespace BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.TurretShooters
{
    public class LaserTurretShooter : MonoBehaviour, ITurretShooter
    {
        [SerializeField] private GameObject _laser;

        private MainCharacter.Scripts.MainCharacter _target;
        private TurretConfig _config;

        public void Init(TurretConfig config)
        {
            _config = config;
            _laser.gameObject.SetActive(false);
        }
        
        public void Shoot(MainCharacter.Scripts.MainCharacter target)
        {
            _target = target;
            StartCoroutine(LaserAttackDelay());
        }

        private IEnumerator LaserAttackDelay()
        {
            Vector3 oldPos = _target.transform.position;
            Vector3 newPos;
            yield return new WaitForSeconds(1.5f);
            newPos = _target.transform.position;

            if (Vector3.Distance(oldPos, newPos) < 0.2f)
            {
                _laser.gameObject.SetActive(true);
                _target.Health.TakeDamage(_config.Damage);
            }
        }
    }
}