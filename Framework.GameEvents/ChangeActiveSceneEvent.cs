using GV.EventBus;
using GV.Globals.Enums;

namespace GV.GameEvents;

public struct ChangeActiveSceneEvent(SceneNames sceneName) : IEvent
{
    public SceneNames SceneName = sceneName;
}