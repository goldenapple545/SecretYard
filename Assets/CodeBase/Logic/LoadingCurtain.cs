using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Logic
{
    public class LoadingCurtain: MonoBehaviour
    {
        public CanvasGroup curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            curtain.alpha = 1;
        }

        public void Hide() =>
            _ = FadeIn();

        private async UniTaskVoid FadeIn()
        {
            float fadeSpeed = 2f;

            while (curtain.alpha > 0)
            {
                curtain.alpha -= fadeSpeed * Time.deltaTime;
                await UniTask.Yield();
            }

            curtain.alpha = 0f;
            gameObject.SetActive(false);
        }
    }
}
