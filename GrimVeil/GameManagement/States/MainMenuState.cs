using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GrimVeil.GameManagement.States;

public class MainMenuState : GameState
{
    public MainMenuState(GameManager stateMachine)
        : base(stateMachine)
    { }

    public override string StateLogString => "Main Menu";

    public override void OnBegin()
    {
        GameManager manager = stateMachine as GameManager;
        if (manager == null)
            return;

        int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        manager.Window.Position = new Point(0, 0);
        manager.Graphics.PreferredBackBufferWidth = screenWidth;
        manager.Graphics.PreferredBackBufferHeight = screenHeight;
        manager.Graphics.IsFullScreen = true;

        manager.Graphics.ApplyChanges();
    }

    public override void OnExit()
    {
    }


    public override void Update(GameTime gameTime)
    {
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
    }
}