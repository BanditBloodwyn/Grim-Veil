namespace GV.Tests.Core.StateMachines;

public class GreenState : TrafficState
{
    public GreenState(TrafficLight stateMachine)
        : base(stateMachine)
    { }

    public override string StateLogString => "Green";

    public override void OnBegin()
    {
    }

    public override void OnExit()
    {
    }
}