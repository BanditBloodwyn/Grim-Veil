namespace Core.Patterns.Behaviours.FiniteStateMachines
{
    public abstract class StateMachine<TState> 
        where TState : State<TState>
    {
        protected TState? CurrentState { get; private set; }
        
        public void ChangeState(TState newState)
        {
            CurrentState?.OnExit();
            newState.OnBegin();
            CurrentState = newState;
        }

        public string GetStateLog()
        {
            return CurrentState?.StateLogString ?? "No state!";
        }
    }
}