using CodeBase.Logic;
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
        private readonly LoadingCurtain _curtain;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, HandleLoaded);
        }

        public void Exit() =>
            _curtain.Hide();

        private void HandleLoaded()
        {
            var initialPoint = GameObject.FindWithTag(InitialPointTag);

            GameObject player = Instantiate(PlayerPrefab, at: initialPoint.transform.position);

            _stateMachine.Enter<GameLoopState>();
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
