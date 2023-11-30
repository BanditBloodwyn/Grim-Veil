using Managers.SceneManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Settings;

namespace Managers.StateManagement.Program.States;

public class SplashScreenState : GameState
{
    private const float MINIMUM_SPLASHSCREEN_TIME_SECONDS = 2f;

    public override string StateLogString => "Splash Screen State";
    protected override string AssociatedSceneName => "splashScreen";

    public SplashScreenState(GameManager stateMachine)
        : base(stateMachine)
    { }

    protected override void OnInitialize()
    {
        int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        stateMachine.Window.Position = new Point(screenWidth / 2 - GlobalSettings.SPLASHSCREEN_WIDTH / 2, screenHeight / 2 - GlobalSettings.SPLASHSCREEN_HEIGHT / 2);
        stateMachine.Graphics.PreferredBackBufferWidth = GlobalSettings.SPLASHSCREEN_WIDTH;
        stateMachine.Graphics.PreferredBackBufferHeight = GlobalSettings.SPLASHSCREEN_HEIGHT;
        stateMachine.Window.IsBorderless = true;

        stateMachine.Graphics.ApplyChanges();
    }

    public override void Update(GameTime gameTime)
    {
        TimeSpan startingTime = gameTime.TotalGameTime;

        while (startingTime.TotalSeconds < MINIMUM_SPLASHSCREEN_TIME_SECONDS)
            return;
       
        SceneManager.AddScene("loadingScreen", SceneBuilder.LoadingScreen());
       
        ChangeState(new LoadingScreenState(stateMachine));
    }
}