using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PlayerUI
{
    public class LoadIndicator: MonoBehaviour
    {
        [Header("Количество секунд")]
        [SerializeField] private float sec;
        [Header("Установить ссылку на индикатор заполнения прогресса")]
        [SerializeField] private Image fulled;
        [Header("Установить ссылку на UI индикатора")]
        [SerializeField] private GameObject indicator;

        public UnityEvent OnIndicatorFilled;
        
        private float _currentProgress = 0;

        public void SetSeconds(float value)
        {
            if (value > 0)
                sec = value;
        }
        
        private void OnEnable()
        {
            if (indicator)
                indicator.SetActive(true);
            StartCoroutine(FillIndicator(sec));
        }

        private void OnDisable()
        {
            if (indicator)
                indicator.SetActive(false);
            _currentProgress = 0f;
            fulled.fillAmount = 0;
        }

        private IEnumerator FillIndicator(float seconds)
        {
            while (_currentProgress < 1f)
            {
                _currentProgress += Time.deltaTime / seconds;
                if (fulled)
                    fulled.fillAmount = _currentProgress;
                
                yield return null;
            }
            
            OnIndicatorFilled?.Invoke();
        }
    }
}