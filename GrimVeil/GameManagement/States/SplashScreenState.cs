using GrimVeil.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrimVeil.GameManagement.States;

public class SplashScreenState : GameState
{
    private const float MINIMUM_SPLASHSCREEN_TIME_SECONDS = 3f;
    private const int SPLASHSCREEN_WIDTH = 800;
    private const int SPLASHSCREEN_HEIGHT = 499;

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
            ContentLoader.Textures["splashscreen"],
            new Rectangle(0, 0, SPLASHSCREEN_WIDTH, SPLASHSCREEN_HEIGHT),
            Color.White);
    }
}