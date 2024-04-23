namespace GV.Tests.Core.StateMachines;

public class GreenState(TrafficLight stateMachine) : TrafficState(stateMachine)
{
    public override string StateLogString => "Green";

    public override void OnBegin()
    {
    }

    public override void OnExit()
    {
    }
}