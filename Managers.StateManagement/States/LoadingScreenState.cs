using GV.EventBus;
using GV.GameEvents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GV.StateManagement.States;

public class LoadingScreenState(GameManager stateMachine) : GameState(stateMachine)
{
    private TimeSpan? _startingTime;

    public override string StateLogString => "Loading Screen";

    protected override void Initialize()
    {
        StateMachine.Window.Position = new Point(0, 0);
        StateMachine.Graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        StateMachine.Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        StateMachine.Graphics.ApplyChanges();

        EventBus<ChangeActiveSceneEvent>.Raise(new ChangeActiveSceneEvent("LoadingScreenScene"));
    }

    public override void Update(GameTime gameTime)
    {
        _startingTime ??= gameTime.TotalGameTime;

        while (gameTime.TotalGameTime.TotalSeconds - _startingTime.Value.TotalSeconds < 1)
            return;

        ChangeState(GameStateFactory.BuildByType<MainMenuState>());
    }
}