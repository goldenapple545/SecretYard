using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
    public class SceneLoader
    {
        public void Load(string name, Action onLoaded = null) =>
            _ = LoadScene(name, onLoaded);

        private async UniTaskVoid LoadScene(string name, Action onLoaded = null)
        {
            if (name == SceneManager.GetActiveScene().name)
            {
                onLoaded?.Invoke();
                return;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            await waitNextScene.ToUniTask();

            onLoaded?.Invoke();
        }
    }
}
