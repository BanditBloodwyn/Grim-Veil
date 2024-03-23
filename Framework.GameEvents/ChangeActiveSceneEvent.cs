using GV.EventBus;
using GV.Globals.Enums;

namespace GameEvents;

public struct ChangeActiveSceneEvent : IEvent
{
    public SceneNames SceneName;

    public ChangeActiveSceneEvent(SceneNames sceneName)
    {
        SceneName = sceneName;
    }
}