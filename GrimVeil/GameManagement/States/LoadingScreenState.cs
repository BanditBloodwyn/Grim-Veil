using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using UI.Core;

namespace GrimVeil.GameManagement.States;

public class LoadingScreenState : GameState
{
    private readonly int _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    private readonly int _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

    public override string StateLogString => "Loading Screen";

    public LoadingScreenState(GameManager stateMachine, ContentManager content)
        : base(stateMachine, content)
    { }

    protected override void OnLoadContent()
    {
        ContentPool.LoadLoadingScreenContent(Content);

        ObjectPool.AddObject(
            "loadingScreen_Background1",
            new Image(
                ContentPool.Textures["loadingScreen_Background1"],
                new Rectangle(0, 0, _screenWidth, _screenHeight)));
    }

    protected override void OnInitialize()
    {
        stateMachine.Window.Position = new Point(0, 0);
        stateMachine.Graphics.PreferredBackBufferWidth = _screenWidth;
        stateMachine.Graphics.PreferredBackBufferHeight = _screenHeight;
        stateMachine.Graphics.IsFullScreen = true;
        stateMachine.Graphics.ApplyChanges();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        ContentPool.LoadContent(Content);

        ChangeState(new MainMenuState(stateMachine, Content));
    }
}