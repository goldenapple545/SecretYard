using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper: MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain curtain;

        private Game _game;

        private void Awake()
        {
            _game = new Game(curtain);
            _game.stateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
