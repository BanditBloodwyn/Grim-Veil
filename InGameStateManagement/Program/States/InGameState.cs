namespace Managers.StateManagement.Program.States;

public class InGameState : GameState
{
    public override string StateLogString => "In Game";
    protected override string AssociatedSceneName => "inGameScene";

    public InGameState(GameManager stateMachine)
        : base(stateMachine)
    { }
}