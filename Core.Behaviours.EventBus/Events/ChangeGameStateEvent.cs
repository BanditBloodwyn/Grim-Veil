namespace Core.Patterns.Behaviours.EventBus.Events;

public struct ChangeGameStateEvent : IEvent
{
    public string SceneName;

    public ChangeGameStateEvent(string sceneName)
    {
        SceneName = sceneName;
    }
}