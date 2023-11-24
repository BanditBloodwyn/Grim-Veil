namespace Core.Patterns.Behaviours.FiniteStateMachines;

public abstract class StateMachine<TState, TStateMachine> 
    where TState : State<TState, TStateMachine>
    where TStateMachine : StateMachine<TState, TStateMachine> 
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