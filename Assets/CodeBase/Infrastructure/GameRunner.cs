using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstrapper bootstrapperPrefab;

        private void Awake()
        {
            var bootstrapper = FindAnyObjectByType<GameBootstrapper>();

            if (bootstrapper == null)
            {
                Instantiate(bootstrapperPrefab);
            }
        }
    }
}
