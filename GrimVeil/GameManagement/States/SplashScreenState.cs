using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using System;
using UI.Core;

namespace GrimVeil.GameManagement.States;

public class SplashScreenState : GameState
{
    private const float MINIMUM_SPLASHSCREEN_TIME_SECONDS = 2f;
    private const int SPLASHSCREEN_WIDTH = 900;
    private const int SPLASHSCREEN_HEIGHT = 561;

    public override string StateLogString => "Splash Screen State";

    public SplashScreenState(GameManager stateMachine, ContentManager content)
        : base(stateMachine, content)
    { }

    protected override void OnLoadContent()
    {
        ContentPool.LoadSplashScreenContent(Content);

        ObjectPool.AddObject(
            "background",
            new Image(
                ContentPool.Textures["splashscreen"],
                new Rectangle(0, 0, SPLASHSCREEN_WIDTH, SPLASHSCREEN_HEIGHT)));
        ObjectPool.AddObject(
            "logo",
            new Image(
                ContentPool.Textures["gameLogo"],
                new Rectangle(SPLASHSCREEN_WIDTH / 6, 0, (int)(SPLASHSCREEN_WIDTH / 1.5f), SPLASHSCREEN_WIDTH / 4)));
    }

    protected override void OnInitialize()
    {
        int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        stateMachine.Window.Position = new Point(screenWidth / 2 - SPLASHSCREEN_WIDTH / 2, screenHeight / 2 - SPLASHSCREEN_HEIGHT / 2);
        stateMachine.Graphics.PreferredBackBufferWidth = SPLASHSCREEN_WIDTH;
        stateMachine.Graphics.PreferredBackBufferHeight = SPLASHSCREEN_HEIGHT;
        stateMachine.Window.IsBorderless = true;

        stateMachine.Graphics.ApplyChanges();
    }

    public override void Update(GameTime gameTime)
    {
        TimeSpan startingTime = gameTime.TotalGameTime;

        while (startingTime.TotalSeconds < MINIMUM_SPLASHSCREEN_TIME_SECONDS)
            return;

        ChangeState(new LoadingScreenState(stateMachine, Content));
    }
}