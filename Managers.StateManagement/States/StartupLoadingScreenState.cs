using GV.SceneManagement.Data;
using GV.StateManagement.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GV.StateManagement.States;

public class StartupLoadingScreenState : GameState
{
    private TimeSpan? _startingTime;

    public override string StateLogString => "Loading Screen";

    protected override StateNames StateName => StateNames.StartupLoadingScreen;

    protected override SceneNames? AssociatedSceneName => SceneNames.StartupLoadingScreen;

    internal StartupLoadingScreenState(GameManager stateMachine)
        : base(stateMachine)
    { }

    protected override void Initialize()
    {
        StateMachine.Window.Position = new Point(0, 0);
        StateMachine.Graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        StateMachine.Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        StateMachine.Graphics.ApplyChanges();
    }

    public override void Update(GameTime gameTime)
    {
        _startingTime ??= gameTime.TotalGameTime;

        while (gameTime.TotalGameTime.TotalSeconds - _startingTime.Value.TotalSeconds < 1)
            return;

        ChangeState(GameStateFactory.BuildByName(StateNames.MainMenu));
    }
}