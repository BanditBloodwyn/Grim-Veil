using GV.EventBus;
using GV.Globals.Enums;

namespace GV.GameEvents;

public struct ChangeGameStateEvent : IEvent
{
    public StateNames StateName;

    public ChangeGameStateEvent(StateNames stateName)
    {
        StateName = stateName;
    }
}