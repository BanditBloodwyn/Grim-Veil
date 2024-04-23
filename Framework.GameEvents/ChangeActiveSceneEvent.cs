using GV.EventBus;
using GV.SceneManagement.Data;

namespace GV.GameEvents;

public struct ChangeActiveSceneEvent(SceneNames sceneName) : IEvent
{
    public SceneNames SceneName = sceneName;
}