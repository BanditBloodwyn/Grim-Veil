namespace GV.Tests.Core.StateMachines;

public class RedState(TrafficLight stateMachine) : TrafficState(stateMachine)
{
    public override string StateLogString => "Red";

    public override void OnBegin()
    {
    }

    public override void OnExit()
    {
    }
}