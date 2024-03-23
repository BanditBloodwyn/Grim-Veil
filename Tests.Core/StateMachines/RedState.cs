namespace GV.Tests.Core.StateMachines;

public class RedState : TrafficState
{
    public override string StateLogString => "Red";

    public RedState(TrafficLight stateMachine)
        : base(stateMachine)
    { }

    public override void OnBegin()
    {
    }

    public override void OnExit()
    {
    }
}