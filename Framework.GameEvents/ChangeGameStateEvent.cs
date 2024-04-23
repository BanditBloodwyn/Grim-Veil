using GV.EventBus;

namespace GV.GameEvents;

public struct ChangeGameStateEvent(string stateName) : IEvent
{
    public string StateName = stateName;
}