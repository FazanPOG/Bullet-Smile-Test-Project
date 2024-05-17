using System;
using BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts;
using UnityEngine;

namespace BulletSmileTestProject.Prefabs.Levels.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class EndPoint : MonoBehaviour
    {
        private BoxCollider _collider;

        public event Action OnEndTriggered;
        
        private void Awake() => _collider = GetComponent<BoxCollider>();
        private void OnEnable() => _collider.isTrigger = true;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out MainCharacter mainCharacter))
                mainCharacter.EndGameState();
        }
    }
}
