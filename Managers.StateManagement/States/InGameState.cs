using GV.EventBus;
using GV.GameEvents;
using GV.UtilityObjects;
using Microsoft.Xna.Framework;

namespace GV.StateManagement.States;

public class InGameState(GameManager stateMachine) : GameState(stateMachine)
{
    public override string StateLogString => "In Game";

    protected override void Initialize()
    {
        EventBus<ChangeActiveSceneEvent>.Raise(new ChangeActiveSceneEvent("InGameScene"));
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        GameCamera.Instance.Update(gameTime);
    }
}