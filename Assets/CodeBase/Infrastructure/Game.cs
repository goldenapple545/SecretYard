using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine stateMachine;

        public Game(LoadingCurtain curtain)
        {
            stateMachine = new GameStateMachine(new SceneLoader(), curtain, AllServices.Container);
        }
    }
}
