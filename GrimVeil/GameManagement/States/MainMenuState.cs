using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using UI.Core;

namespace GrimVeil.GameManagement.States;

public class MainMenuState : GameState
{
    private const int LOGO_SIZE_DEVIDER = 9;

    private readonly int _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    private readonly int _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

    public override string StateLogString => "Main Menu";
   
    public MainMenuState(GameManager stateMachine)
        : base(stateMachine)
    { }

    protected override void OnLoadContent()
    {
        ObjectPool.AddObject(
            "mainMenu_Background",
            new Image(
                ContentPool.Textures["mainMenu_Background"],
                new Rectangle(0, 0, _screenWidth, _screenHeight)));
        ObjectPool.AddObject(
            "mainMenu_Logo",
            new Image(
                ContentPool.Textures["gameLogo_dark"],
                new Rectangle(100, 0,
                    (int)(_screenWidth / (LOGO_SIZE_DEVIDER * 0.25f)),
                    _screenWidth / (LOGO_SIZE_DEVIDER * 2 / 3))));

        ObjectPool.AddObject("newGameButton", CreateButton("New Game", ContentPool.Fonts["Victorian"], _screenWidth - 400, _screenHeight - 500));
    }

    private Button CreateButton(string text, SpriteFont font, int posX, int posY)
    {
        Button button = new(
            new Rectangle(posX, posY - 500, (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y));
        button.Text = text;
        button.SpriteFont = font;

        return button;
    }

    protected override void OnInitialize()
    {
        GameManager manager = stateMachine as GameManager;
        if (manager == null)
            return;

        manager.Window.Position = new Point(0, 0);
        manager.Graphics.PreferredBackBufferWidth = _screenWidth;
        manager.Graphics.PreferredBackBufferHeight = _screenHeight;
        manager.Graphics.IsFullScreen = true;

        manager.Graphics.ApplyChanges();
    }

    public override void OnExit()
    {
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        base.Draw(spriteBatch, gameTime);

        float menuPositionX = _screenWidth - 400;
        float menuPositionY = _screenHeight;

        //spriteBatch.DrawString(ContentPool.Fonts["Victorian"], "New Game",
        //    new Vector2(menuPositionX, menuPositionY - 500), Color.White);
        //spriteBatch.DrawString(ContentPool.Fonts["Victorian"], "Load",
        //    new Vector2(menuPositionX, menuPositionY - 430), Color.White);
        //spriteBatch.DrawString(ContentPool.Fonts["Victorian"], "Settings",
        //    new Vector2(menuPositionX, menuPositionY - 360), Color.White);
        //spriteBatch.DrawString(ContentPool.Fonts["Victorian"], "Extras",
        //    new Vector2(menuPositionX, menuPositionY - 290), Color.White);
        //spriteBatch.DrawString(ContentPool.Fonts["Victorian"], "Credits",
        //    new Vector2(menuPositionX, menuPositionY - 220), Color.White);
        //spriteBatch.DrawString(ContentPool.Fonts["Victorian"], "Quit",
        //    new Vector2(menuPositionX, menuPositionY - 150), Color.White);
    }
}