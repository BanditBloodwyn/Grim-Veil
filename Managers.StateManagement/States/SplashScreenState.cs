using GV.Globals;
using GV.Globals.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GV.StateManagement.States;

public class SplashScreenState : GameState
{
    public override string StateLogString => "Splash Screen State";

    protected override StateNames StateName => StateNames.SplashScreen;

    protected override SceneNames? AssociatedSceneName => SceneNames.SplashScreen;

    internal SplashScreenState(GameManager stateMachine)
        : base(stateMachine)
    { }

    protected override void Initialize()
    {
        int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        StateMachine.Window.Position = new Point(screenWidth / 2 - Settings.SPLASHSCREEN_WIDTH / 2, screenHeight / 2 - Settings.SPLASHSCREEN_HEIGHT / 2);
        StateMachine.Graphics.PreferredBackBufferWidth = Settings.SPLASHSCREEN_WIDTH;
        StateMachine.Graphics.PreferredBackBufferHeight = Settings.SPLASHSCREEN_HEIGHT;
        StateMachine.Window.IsBorderless = true;

        StateMachine.Graphics.ApplyChanges();
    }

    public override void Update(GameTime gameTime)
    {
        TimeSpan startingTime = gameTime.TotalGameTime;

        while (startingTime.TotalSeconds < Settings.MINIMUM_SPLASHSCREEN_TIME_SECONDS)
            return;

        ChangeState(GameStateFactory.BuildByName(StateNames.StartupLoadingScreen));
    }
}