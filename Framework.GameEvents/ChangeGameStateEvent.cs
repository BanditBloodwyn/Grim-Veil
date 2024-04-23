using GV.EventBus;
using GV.Globals.Enums;

namespace GV.GameEvents;

public struct ChangeGameStateEvent(StateNames stateName) : IEvent
{
    public StateNames StateName = stateName;
}