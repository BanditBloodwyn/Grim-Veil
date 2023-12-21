using Core.Patterns.Behaviours.EventBus;
using Globals.Enums;

namespace Framework.GameEvents;

public struct ChangeGameStateEvent : IEvent
{
    public StateNames StateName;

    public ChangeGameStateEvent(StateNames stateName)
    {
        StateName = stateName;
    }
}