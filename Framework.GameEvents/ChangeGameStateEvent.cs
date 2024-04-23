using GV.EventBus;
using GV.StateManagement.Data;

namespace GV.GameEvents;

public struct ChangeGameStateEvent(StateNames stateName) : IEvent
{
    public StateNames StateName = stateName;
}