using BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts.Interfaces;
using UnityEngine;

namespace BulletSmileTestProject.Prefabs.Characters.MainCharacter.Scripts
{
    public class JumpArrowRenderer : MonoBehaviour
    {
        [SerializeField] private Transform _arrowTransform; 
        
        private IInputHandler _inputHandler;
        
        public void Init(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void Update()
        {
            Vector2 normalizedVector = _inputHandler.JumpDirection.normalized;
            
            float angleRadians = Mathf.Atan2(normalizedVector.y, normalizedVector.x);
            float angleDegrees = angleRadians * Mathf.Rad2Deg;
            
            _arrowTransform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);
            _arrowTransform.localScale = new Vector3(normalizedVector.magnitude, _arrowTransform.localScale.y, _arrowTransform.localScale.z);
        }
    }
}