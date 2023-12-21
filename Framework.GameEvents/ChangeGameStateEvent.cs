using Core.Patterns.Behaviours.EventBus;
using Globals.Enums;

namespace Framework.GameEvents;

public struct ChangeGameStateEvent : IEvent
{
    public SceneNames SceneName;

    public ChangeGameStateEvent(SceneNames sceneName)
    {
        SceneName = sceneName;
    }
}