namespace GV.FiniteStateMachines;

public abstract class State<TState, TStateMachine>(TStateMachine stateMachine)
    where TState : State<TState, TStateMachine>
    where TStateMachine : StateMachine<TState, TStateMachine>
{
    protected TStateMachine StateMachine { get; } = stateMachine;

    public abstract string StateLogString { get; }

    public virtual void OnBegin() {}

    public virtual void OnExit() {}

    protected void ChangeState(TState state)
    {
        StateMachine.ChangeState(state);
    }
}