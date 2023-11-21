namespace Core.Patterns.Behaviours.FiniteStateMachines;

public abstract class State<TState> 
    where TState : State<TState>
{
    protected readonly StateMachine<TState> stateMachine;
  
    public abstract string StateLogString { get; }

    protected State(StateMachine<TState> stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public abstract void OnBegin();

    public abstract void OnExit();

    protected void ChangeState(TState state)
    {
        stateMachine.ChangeState(state);
    }

}