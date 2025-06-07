using System.ComponentModel.Design;

namespace CodeBase.Infrastructure
{
    public interface IExitableState
    {
        void Exit();
    }

    public interface IState: IExitableState
    {
        void Enter();
    }

    public interface IPayLoadState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}
