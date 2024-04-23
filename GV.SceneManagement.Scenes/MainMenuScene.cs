using GV.EventBus;
using GV.GameEvents;
using GV.Globals;
using GV.Pools;
using GV.UIObjects;
using GV.UIObjects.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GV.SceneManagement.Scenes;

public class MainMenuScene : Scene
{
    private static readonly int _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    private static readonly int _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

    public override void LoadResources()
    {
        ResourcePool.LoadAsset<Texture2D>("mainMenu_Background", "Images/title");
    }

    public override void Build()
    {
        Name = "Main Menu Scene";

        Image background = new(new Rectangle(0, 0, _screenWidth, _screenHeight));
        background.Texture = ResourcePool.GetAsset<Texture2D>("mainMenu_Background");
        AddObject("mainMenu_Background", background);

        Image logo = new(new Rectangle(30, 10,
            _screenWidth / Settings.LOGO_SIZE_DEVIDER * 3,
            _screenWidth / Settings.LOGO_SIZE_DEVIDER * 3));
        logo.Texture = ResourcePool.GetAsset<Texture2D>("gameLogo");
        AddObject("mainMenu_Logo", logo);

        SpriteFont font = ResourcePool.GetAsset<SpriteFont>("default");
        AddObject("button_newGame", ButtonFactory.CreateTextButton("New Game", font,
            _screenWidth - 400, _screenHeight - 500, new Vector2(2),
            static (_, _) => EventBus<ChangeGameStateEvent>.Raise(new ChangeGameStateEvent("InGameState"))));
        AddObject("button_loadGame", ButtonFactory.CreateTextButton("Load", font,
            _screenWidth - 400, _screenHeight - 450, new Vector2(2), null));
        AddObject("button_settings", ButtonFactory.CreateTextButton("Settings", font,
            _screenWidth - 400, _screenHeight - 400, new Vector2(2), null));
        AddObject("button_extras", ButtonFactory.CreateTextButton("Extras", font,
            _screenWidth - 400, _screenHeight - 350, new Vector2(2), null));
        AddObject("button_credits", ButtonFactory.CreateTextButton("Credits", font,
            _screenWidth - 400, _screenHeight - 300, new Vector2(2), null));
        AddObject("button_quit", ButtonFactory.CreateTextButton("Quit", font,
            _screenWidth - 400, _screenHeight - 250, new Vector2(2),
            static (_, _) => EventBus<RequestExitGameEvent>.Raise(new RequestExitGameEvent())));

    }
}