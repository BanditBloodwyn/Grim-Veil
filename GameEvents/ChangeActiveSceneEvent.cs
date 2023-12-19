using Core.Patterns.Behaviours.EventBus;
using Globals.Enums;

namespace Framework.GameEvents;

public struct ChangeActiveSceneEvent : IEvent
{
    public SceneNames SceneName;

    public ChangeActiveSceneEvent(SceneNames sceneName)
    {
        SceneName = sceneName;
    }
}