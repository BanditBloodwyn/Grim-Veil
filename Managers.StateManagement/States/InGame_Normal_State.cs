using GV.Globals.Enums;
using GV.UtilityObjects;
using Microsoft.Xna.Framework;

namespace GV.StateManagement.States;

public class InGame_Normal_State : GameState
{
    public override string StateLogString => "In Game";

    protected override StateNames StateName => StateNames.Ingame_Normal;

    protected override SceneNames? AssociatedSceneName => SceneNames.Ingame_Normal;

    internal InGame_Normal_State(GameManager stateMachine)
        : base(stateMachine)
    { }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        GameCamera.Instance.Update(gameTime);
    }
}