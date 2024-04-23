using GV.FiniteStateMachines;

namespace GV.Tests.Core.StateMachines;

public abstract class TrafficState(TrafficLight stateMachine) : State<TrafficState, TrafficLight>(stateMachine);