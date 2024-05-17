using System.Collections;
using BulletSmileTestProject.Architecture.Configs.MainCharacter.Scripts;
using BulletSmileTestProject.Architecture.Services.Scripts.Interfaces;
using UnityEngine;

namespace BulletSmileTestProject.Architecture.Services.Scripts
{
    public class TimeService : ITimeService
    {
        private readonly MonoBehaviour _context;

        private MainCharacterConfig _config;
        
        public TimeService(MainCharacterConfig config, MonoBehaviour context)
        {
            _config = config;
            _context = context;
        }
        
        public void SlowDownTime()
        {
            float slowDownTimeDuration = _config.SlowDownTimeDuration;
            _context.StartCoroutine(SlowDownTimeScale(slowDownTimeDuration));
        }

        public void SpeedUpTime()
        {
            float slowDownTimeDuration = _config.SlowDownTimeDuration;
            _context.StopAllCoroutines();
            Time.timeScale = 1f;
        }

        private IEnumerator SlowDownTimeScale(float duration)
        {
            float startValue = 1f;
            float deltaScale = (0 - startValue) / duration;
            float elapsed = 0f;

            while (elapsed < duration && Time.timeScale > 0.25f)
            {
                elapsed += Time.deltaTime;
                Time.timeScale = Mathf.Clamp01(startValue + deltaScale * elapsed);
                yield return null;
            }

            Time.timeScale = 0;
        }
    }
}