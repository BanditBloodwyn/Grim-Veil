namespace Core.Patterns.Behaviours.EventBus.Events;

public struct ChangeGameStateEvent : IEvent
{
    public string StateName;

    public ChangeGameStateEvent(string stateName)
    {
        StateName = stateName;
    }
}