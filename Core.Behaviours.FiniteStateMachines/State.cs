﻿namespace Core.Patterns.Behaviours.FiniteStateMachines;

public abstract class State<TState, TStateMachine>
    where TState : State<TState, TStateMachine>
    where TStateMachine : StateMachine<TState, TStateMachine>
{
    protected readonly TStateMachine stateMachine;
  
    public abstract string StateLogString { get; }

    protected State(TStateMachine stateMachine)
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