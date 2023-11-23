using Core.Patterns.Behaviours.FiniteStateMachines;

namespace Tests.Core.StateMachines;

public abstract class TrafficState : State<TrafficState, TrafficLight>
{
    protected TrafficState(TrafficLight stateMachine) 
        : base(stateMachine)
    { }
}