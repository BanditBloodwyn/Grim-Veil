namespace GV.FiniteStateMachines;

public abstract class State<TState, TStateMachine>
    where TState : State<TState, TStateMachine>
    where TStateMachine : StateMachine<TState, TStateMachine>
{
    protected TStateMachine StateMachine { get; }
  
    public abstract string StateLogString { get; }

    protected State(TStateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public virtual void OnBegin() {}

    public virtual void OnExit() {}

    protected void ChangeState(TState state)
    {
        StateMachine.ChangeState(state);
    }
}