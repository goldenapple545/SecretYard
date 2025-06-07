using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string PlayerPrefab = "Player/Player";
        private const string InitialPointTag = "InitialPoint";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) =>
            _sceneLoader.Load(sceneName, HandleLoaded);

        public void Exit()
        {

        }

        private void HandleLoaded()
        {
            var initialPoint = GameObject.FindWithTag(InitialPointTag);

            GameObject player = Instantiate(PlayerPrefab, at: initialPoint.transform.position);
        }

        private static GameObject Instantiate(string path)
        {
            var playerPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(playerPrefab);
        }

        private static GameObject Instantiate(string path, Vector3 at)
        {
            var playerPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(playerPrefab, at, quaternion.identity);
        }
    }
}
