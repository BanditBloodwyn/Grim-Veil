namespace Managers.StateManagement.Program.States;

public class MainMenuState : GameState
{
    public override string StateLogString => "Main Menu";
    protected override string AssociatedSceneName => "mainMenuScreen";

    public MainMenuState(GameManager stateMachine)
        : base(stateMachine)
    { }
}