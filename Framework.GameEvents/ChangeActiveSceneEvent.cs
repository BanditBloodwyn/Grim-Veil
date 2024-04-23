using GV.EventBus;

namespace GV.GameEvents;

public struct ChangeActiveSceneEvent(string sceneName) : IEvent
{
    public string SceneName = sceneName;
}