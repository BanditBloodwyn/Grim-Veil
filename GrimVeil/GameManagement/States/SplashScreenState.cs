using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using System;

namespace GrimVeil.GameManagement.States;

public class SplashScreenState : GameState
{
    private const float MINIMUM_SPLASHSCREEN_TIME_SECONDS = 2f;
    private const int SPLASHSCREEN_WIDTH = 900;
    private const int SPLASHSCREEN_HEIGHT = 561;

    public override string StateLogString => "Splash Screen State";

    public SplashScreenState(GameManager stateMachine)
        : base(stateMachine)
    { }

    public override void OnBegin()
    {
        GameManager manager = stateMachine as GameManager;
        if (manager == null)
            return;

        int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        manager.Window.Position = new Point(screenWidth / 2 - SPLASHSCREEN_WIDTH / 2, screenHeight / 2 - SPLASHSCREEN_HEIGHT / 2);
        manager.Graphics.PreferredBackBufferWidth = SPLASHSCREEN_WIDTH;
        manager.Graphics.PreferredBackBufferHeight = SPLASHSCREEN_HEIGHT;
        manager.Window.IsBorderless = true;

        manager.Graphics.ApplyChanges();
    }

    public override void OnExit()
    {
    }

    public override void Update(GameTime gameTime)
    {
        TimeSpan startingTime = gameTime.TotalGameTime;

        while (startingTime.TotalSeconds < MINIMUM_SPLASHSCREEN_TIME_SECONDS)
            return;

        stateMachine.ChangeState(new MainMenuState(stateMachine as GameManager));
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        spriteBatch.Draw(
            ContentPool.Textures["splashscreen"],
            new Rectangle(0, 0, SPLASHSCREEN_WIDTH, SPLASHSCREEN_HEIGHT),
            Color.White);
        spriteBatch.Draw(
            ContentPool.Textures["gameLogo"],
            new Rectangle(SPLASHSCREEN_WIDTH / 6, 0, (int)(SPLASHSCREEN_WIDTH / 1.5f), SPLASHSCREEN_WIDTH / 4),
            Color.White);
    }
}