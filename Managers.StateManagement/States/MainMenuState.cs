using GV.Globals.Enums;

namespace GV.StateManagement.States;

public class MainMenuState : GameState
{
    public override string StateLogString => "Main Menu";

    protected override StateNames StateName => StateNames.MainMenu;

    protected override SceneNames? AssociatedSceneName => SceneNames.MainMenu;

    internal MainMenuState(GameManager stateMachine)
        : base(stateMachine)
    { }
}