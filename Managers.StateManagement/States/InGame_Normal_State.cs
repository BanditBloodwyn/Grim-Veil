using Globals.Enums;

namespace Managers.StateManagement.States;

public class InGame_Normal_State : GameState
{
    public override string StateLogString => "In Game";
   
    protected override SceneNames? AssociatedSceneName => SceneNames.Ingame_Normal;

    internal InGame_Normal_State(GameManager stateMachine)
        : base(stateMachine)
    { }
}