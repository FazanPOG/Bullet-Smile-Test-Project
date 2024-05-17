using System;
using UnityEngine;

namespace BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Bullet : MonoBehaviour
    {
        private int _damage;
        private bool _isInitialized;
        private Action<Bullet> _onCollisionEnterCallback;

        public void Init(int damage, Action<Bullet> onCollisionEnterCallback)
        {
            _damage = damage;
            _onCollisionEnterCallback = onCollisionEnterCallback;
            
            _isInitialized = true;
        }

        private void Update()
        {
            if(_isInitialized)
                Move();
        }

        private void Move()
        {
            float speed = 3f;
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }

        private void OnCollisionEnter(Collision other)
        {
            if(_isInitialized == false) throw new Exception($"Bullet does not initialized: {typeof(Bullet)}");
            
            if(other.collider.TryGetComponent(out MainCharacter.Scripts.MainCharacter mainCharacter))
                mainCharacter.Health.TakeDamage(_damage);
            
            _onCollisionEnterCallback.Invoke(this);
        }
    }
}
