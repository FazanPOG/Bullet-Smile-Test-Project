using System.Collections;
using BulletSmileTestProject.Architecture.Configs.Turrets.Scripts;
using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.Interfaces;
using UnityEngine;

namespace BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts
{
    public abstract class BaseTurret : MonoBehaviour
    {
        [SerializeField] private TurretConfig _config;
        [SerializeField] private Transform _ammoSpawnPoint;
        [SerializeField, TextArea(1, 5)] private string DEBUG_STRING;
        
        private MainCharacter.Scripts.MainCharacter _mainCharacter;
        private bool _isCoroutineRunning;

        public TurretConfig Config => _config;
        public Transform AmmoSpawnPoint => _ammoSpawnPoint;
        protected ITurretShooter Shooter { get; private set; }

        public void Init(ITurretShooter turretShooter)
        {
            Shooter = turretShooter;
        }

        private void Update()
        {
            if(HasTarget() == false)
                FindTarget();
            else
                Shoot();    
        }

        private void UpdateDebugString()
        {
            if (_mainCharacter != null)
            {
                var position = transform.position;
                Vector3 directionToMainCharacter = (_mainCharacter.transform.position - position).normalized;

                bool isCollide = Physics.Raycast(position, directionToMainCharacter, out RaycastHit hit, _config.AttackRange);
                bool isMainCharacter = hit.transform == _mainCharacter.transform;

                DEBUG_STRING = $"Has look object: {isCollide} \n" +
                               $"Look object name: {hit.collider.name} \n" +
                               $"Is look object - MainCharacter: {isMainCharacter} \n";
            }
        }
        
        private void Shoot()
        {
            if(Shooter == null)
                throw new MissingComponentException($"Missing component: {typeof(ITurretShooter)}");
            
            Rotate();

            Vector3 directionToMainCharacter = (_mainCharacter.transform.position - transform.position).normalized;
            if (IsLineOfSightClear(directionToMainCharacter))
            {
                if (_isCoroutineRunning == false)
                    StartCoroutine(ShootWithAttackDelay(_mainCharacter));
            }
        }

        private bool HasTarget()
        {
            return _mainCharacter != null;
        }
        
        private void FindTarget()
        {
            foreach (var item in Physics.OverlapSphere(transform.position, _config.AttackRange))
            {
                if(item.TryGetComponent(out MainCharacter.Scripts.MainCharacter mainCharacter))
                {
                    _mainCharacter = mainCharacter;
                    return;
                }
            }

            _mainCharacter = null;
        }

        private bool IsLineOfSightClear(Vector3 direction)
        {
            if (!Physics.Raycast(transform.position, direction, out RaycastHit hit, _config.AttackRange) 
                || hit.transform == _mainCharacter.transform)
            {
                return true;
            }

            Debug.DrawLine(transform.position, direction, Color.red, _config.AttackRange);
            
            return false;
        }
        
        private void Rotate()
        {
            transform.LookAt(_mainCharacter.transform.position);
        }
        
        private IEnumerator ShootWithAttackDelay(MainCharacter.Scripts.MainCharacter mainCharacter)
        {
            float delay = _config.AttackDelay;
            _isCoroutineRunning = true;
            
            Shooter.Shoot(_mainCharacter);
            yield return new WaitForSeconds(delay);

            _isCoroutineRunning = false;
        }
        
        private void OnDrawGizmos()
        {
            if(_mainCharacter == null) return;

            var position = transform.position;
            Vector3 directionToMainCharacter = (_mainCharacter.transform.position - position).normalized;
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(position, _config.AttackRange);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(position, directionToMainCharacter * _config.AttackRange);
            Gizmos.color = Color.white;
        }
    }
}
