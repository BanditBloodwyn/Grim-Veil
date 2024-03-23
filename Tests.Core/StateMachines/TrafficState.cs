using GV.FiniteStateMachines;

namespace GV.Tests.Core.StateMachines;

public abstract class TrafficState : State<TrafficState, TrafficLight>
{
    protected TrafficState(TrafficLight stateMachine) 
        : base(stateMachine)
    { }
}