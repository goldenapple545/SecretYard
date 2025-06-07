namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine stateMachine;

        public Game()
        {
            stateMachine = new GameStateMachine(new SceneLoader());
        }
    }
}
