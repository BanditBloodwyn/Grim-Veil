using Globals.Enums;

namespace Core.Patterns.Behaviours.EventBus.Events;

public struct ChangeGameStateEvent : IEvent
{
    public StateNames StateName;

    public ChangeGameStateEvent(StateNames stateName)
    {
        StateName = stateName;
    }
}