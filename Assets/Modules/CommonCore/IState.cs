using Cysharp.Threading.Tasks;

namespace Modules.CommonCore
{
    public interface IState : IExitableState
    {
        public UniTask Enter();
    }

    public interface IPayloadedState<TPayload> : IExitableState
    {
        public UniTask Enter(TPayload payload);
    }

    public interface IExitableState
    {
        public UniTask Exit();
    }
}