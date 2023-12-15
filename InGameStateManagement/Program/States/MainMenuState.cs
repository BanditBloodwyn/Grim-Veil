using Globals.Enums;

namespace Managers.StateManagement.Program.States;

public class MainMenuState : GameState
{
    public override string StateLogString => "Main Menu";
    protected override StateNames StateName => StateNames.MainMenu;

    internal MainMenuState(GameManager stateMachine)
        : base(stateMachine)
    { }
}