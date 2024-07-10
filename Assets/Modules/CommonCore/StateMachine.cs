using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Modules.CommonCore
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new();
        public IExitableState CurrentState { get; private set; }

        public event Action<IExitableState> StateEntered;

        public void AddState(IExitableState state)
        {
            _states.Add(state.GetType(), state);
        }

        public async UniTask Enter<TState>() where TState : IState
        {
            var exitCurrent = ExitCurrent();
            var state = GetState<TState>();


            await exitCurrent;
            CurrentState = state;
            await state.Enter();

            StateEntered?.Invoke(CurrentState);
        }

        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : IPayloadedState<TPayload>
        {
            var exitCurrent = ExitCurrent();
            var state = GetState<TState>();

            CurrentState = state;

            await exitCurrent;
            await state.Enter(payload);
            StateEntered?.Invoke(CurrentState);
        }

        public async UniTask ExitCurrent()
        {
            if (CurrentState != null)
            {
                await CurrentState.Exit();
            }
        }

        private TState GetState<TState>() where TState : IExitableState
        {
            return (TState)_states[typeof(TState)];
        }
    }
}