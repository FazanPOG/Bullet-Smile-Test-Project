using DG.Tweening;
using TMPro;
using UnityEngine;

namespace BulletSmileTestProject.UI.Prefabs.ScreenGameplay.Scripts
{
    public class GameInfoUI : MonoBehaviour
    {
        private const string START_TEXT = "Start";
        private const string RESTART_TEXT = "Restart";
        
        [SerializeField] private TextMeshProUGUI _infoText;

        public void StartGameInfo()
        {
            _infoText.text = START_TEXT;
            SmoothFadeTextAnimation();
        }
        
        public void EndGameInfo()
        {
            _infoText.text = RESTART_TEXT;
            ShowUpText();
            ShakeTextAnimation();
        }
        
        private void SmoothFadeTextAnimation()
        {
            _infoText.rectTransform.DOShakePosition(0.5f, strength: new Vector3(10, 10, 0), vibrato: 10, randomness: 90)
                .OnComplete(() =>
                {
                    _infoText.DOFade(0, 2);
                });
        }
        
        private void ShakeTextAnimation()
        {
            _infoText.rectTransform.DOShakePosition(5, strength: new Vector3(10, 10, 0), vibrato: 10,
                randomness: 90);
        }
        
        private void ShowUpText() => _infoText.DOFade(255, 0.1f); 
    }
}
