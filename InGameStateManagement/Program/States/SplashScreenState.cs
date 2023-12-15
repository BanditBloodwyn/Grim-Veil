using Globals;
using Globals.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Managers.StateManagement.Program.States;

public class SplashScreenState : GameState
{
    private const float MINIMUM_SPLASHSCREEN_TIME_SECONDS = 2f;

    public override string StateLogString => "Splash Screen State";
    protected override StateNames StateName => StateNames.SplashScreen;

    internal SplashScreenState(GameManager stateMachine)
        : base(stateMachine)
    { }

    protected override void Initialize()
    {
        int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        stateMachine.Window.Position = new Point(screenWidth / 2 - Settings.SPLASHSCREEN_WIDTH / 2, screenHeight / 2 - Settings.SPLASHSCREEN_HEIGHT / 2);
        stateMachine.Graphics.PreferredBackBufferWidth = Settings.SPLASHSCREEN_WIDTH;
        stateMachine.Graphics.PreferredBackBufferHeight = Settings.SPLASHSCREEN_HEIGHT;
        stateMachine.Window.IsBorderless = true;

        stateMachine.Graphics.ApplyChanges();
    }

    public override void Update(GameTime gameTime)
    {
        TimeSpan startingTime = gameTime.TotalGameTime;

        while (startingTime.TotalSeconds < MINIMUM_SPLASHSCREEN_TIME_SECONDS)
            return;

        ChangeState(GameStateFactory.BuildByName(StateNames.StartupLoadingScreen));
    }
}