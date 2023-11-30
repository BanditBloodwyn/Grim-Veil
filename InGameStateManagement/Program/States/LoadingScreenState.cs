using Managers.SceneManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Managers.StateManagement.Program.States;

public class LoadingScreenState : GameState
{
    private TimeSpan? _startingTime;

    public override string StateLogString => "Loading Screen";
    protected override string AssociatedSceneName => "loadingScreen";

    public LoadingScreenState(GameManager stateMachine)
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

        SceneManager.AddScene("mainMenuScreen", SceneBuilder.MainMenuScreen());

        ChangeState(new MainMenuState(stateMachine));
    }
}