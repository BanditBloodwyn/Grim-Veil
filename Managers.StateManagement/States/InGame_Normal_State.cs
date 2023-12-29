using GameObjects.Utilities;
using Globals.Enums;
using Microsoft.Xna.Framework;

namespace Managers.StateManagement.States;

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

        Camera.Instance.Update(gameTime);
    }
}