using Globals.Enums;

namespace Managers.StateManagement.Program.States;

public class InGame_Normal_State : GameState
{
    public override string StateLogString => "In Game";
   
    protected override StateNames StateName => StateNames.Ingame_Normal;

    internal InGame_Normal_State(GameManager stateMachine)
        : base(stateMachine)
    { }
}