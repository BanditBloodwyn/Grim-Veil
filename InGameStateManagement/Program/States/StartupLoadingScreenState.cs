using Globals.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Managers.StateManagement.Program.States;

public class StartupLoadingScreenState : GameState
{
    private TimeSpan? _startingTime;

    public override string StateLogString => "Loading Screen";
    protected override StateNames StateName => StateNames.StartupLoadingScreen;

    internal StartupLoadingScreenState(GameManager stateMachine)
        : base(stateMachine)
    { }

    protected override void OnInitialize()
    {
        stateMachine.Window.Position = new Point(0, 0);
        stateMachine.Graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        stateMachine.Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        stateMachine.Graphics.ApplyChanges();
    }

    public override void Update(GameTime gameTime)
    {
        _startingTime ??= gameTime.TotalGameTime;

        while (gameTime.TotalGameTime.TotalSeconds - _startingTime.Value.TotalSeconds < 1)
            return;

        ChangeState(GameStateFactory.BuildByName(StateNames.MainMenu));
    }
}