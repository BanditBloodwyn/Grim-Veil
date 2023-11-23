using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using UI.Core;
using UI.Core.Factories;

namespace GrimVeil.GameManagement.States;

public class MainMenuState : GameState
{
    private const int LOGO_SIZE_DEVIDER = 9;

    private readonly int _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    private readonly int _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

    public override string StateLogString => "Main Menu";

    public MainMenuState(GameManager stateMachine, ContentManager content)
        : base(stateMachine, content)
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

        ObjectPool.AddObject("button_newGame", ButtonFactory.CreateTextButton("New Game", ContentPool.Fonts["Victorian"], 
            _screenWidth - 400, _screenHeight - 500, (_, _) => ChangeState(new InGameState(stateMachine, Content))));
        ObjectPool.AddObject("button_loadGame", ButtonFactory.CreateTextButton("Load", ContentPool.Fonts["Victorian"], 
            _screenWidth - 400, _screenHeight - 430, null));
        ObjectPool.AddObject("button_settings", ButtonFactory.CreateTextButton("Settings", ContentPool.Fonts["Victorian"], 
            _screenWidth - 400, _screenHeight - 360, null));
        ObjectPool.AddObject("button_extras", ButtonFactory.CreateTextButton("Extras", ContentPool.Fonts["Victorian"], 
            _screenWidth - 400, _screenHeight - 290, null));
        ObjectPool.AddObject("button_credits", ButtonFactory.CreateTextButton("Credits", ContentPool.Fonts["Victorian"], 
            _screenWidth - 400, _screenHeight - 220, null));
        ObjectPool.AddObject("button_quit", ButtonFactory.CreateTextButton("Quit", ContentPool.Fonts["Victorian"], 
            _screenWidth - 400, _screenHeight - 150, (_, _) => stateMachine.OnExitGame()));
    }
}