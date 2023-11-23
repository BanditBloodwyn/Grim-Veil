using System;
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

        ObjectPool.AddObject("button_newGame", 
            CreateButton("New Game", ContentPool.Fonts["Victorian"], _screenWidth - 400, _screenHeight - 500, null));
        ObjectPool.AddObject("button_loadGame", 
            CreateButton("Load", ContentPool.Fonts["Victorian"], _screenWidth - 400, _screenHeight - 430, null));
        ObjectPool.AddObject("button_settings", 
            CreateButton("Settings", ContentPool.Fonts["Victorian"], _screenWidth - 400, _screenHeight - 360, null));
        ObjectPool.AddObject("button_extras", 
            CreateButton("Extras", ContentPool.Fonts["Victorian"], _screenWidth - 400, _screenHeight - 290, null));
        ObjectPool.AddObject("button_credits", 
            CreateButton("Credits", ContentPool.Fonts["Victorian"], _screenWidth - 400, _screenHeight - 220, null));
        ObjectPool.AddObject("button_quit", 
            CreateButton("Quit", ContentPool.Fonts["Victorian"], _screenWidth - 400, _screenHeight - 150, (_, _) => stateMachine.OnExit()));
    }

    protected override void OnInitialize()
    {
        stateMachine.Window.Position = new Point(0, 0);
        stateMachine.Graphics.PreferredBackBufferWidth = _screenWidth;
        stateMachine.Graphics.PreferredBackBufferHeight = _screenHeight;
        stateMachine.Graphics.IsFullScreen = true;
        stateMachine.Graphics.ApplyChanges();
    }

    public override void OnExit()
    {
    }

    private static Button CreateButton(string text, SpriteFont font, int posX, int posY, EventHandler? @event)
    {
        Button button = new(
            new Rectangle(posX, posY, (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y));
        button.Text = text;
        button.SpriteFont = font;

        if(@event != null) 
            button.Clicked += @event;

        return button;
    }
}