using GV.EventBus;
using GV.GameEvents;

namespace GV.StateManagement.States;

public class MainMenuState(GameManager stateMachine) : GameState(stateMachine)
{
    public override string StateLogString => "Main Menu";

    protected override void Initialize()
    {
        EventBus<ChangeActiveSceneEvent>.Raise(new ChangeActiveSceneEvent("MainMenuScene"));
    }
}