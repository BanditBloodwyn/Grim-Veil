using Core.Patterns.Behaviours.EventBus;
using Core.Patterns.Behaviours.EventBus.Events;
using Maps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using Settings;
using UI.Core;
using UI.Core.Factories;

namespace Managers.SceneManagement;

public class SceneBuilder
{
    private static ContentManager _contentManager = null!;
    private static bool _initialized;

    private static readonly int _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    private static readonly int _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

    public static void Initialize(ContentManager contentManager)
    {
        _contentManager = contentManager;
        _initialized = true;
    }

    public static Scene? BuildByName(string name)
    {
        return name switch
        {
            "splashScreenScene" => SplashScreen(),
            "loadingScreenScene" => LoadingScreen(),
            "mainMenuScene" => MainMenuScreen(),
            "inGameScene" => InGameScene(),
            _ => SplashScreen()
        };
    }

    public static Scene InGameScene()
    {
        if (!_initialized)
            return new Scene();

        ContentPool.LoadMainGameContent(_contentManager);

        Scene scene = new();
        scene.Name = "In Game Scene";

        scene.AddObject("map", new WorldMap());

        return scene;
    }

    public static Scene SplashScreen()
    {
        if (!_initialized)
            return new Scene();

        ContentPool.LoadSplashScreenContent(_contentManager);

        Scene scene = new();

        scene.AddObject(
            "background",
            new Image(
                ContentPool.Textures["splashscreen"],
                new Rectangle(0, 0, GlobalSettings.SPLASHSCREEN_WIDTH, GlobalSettings.SPLASHSCREEN_HEIGHT)));
        scene.AddObject(
            "logo",
            new Image(
                ContentPool.Textures["gameLogo"],
                new Rectangle(GlobalSettings.SPLASHSCREEN_WIDTH / 6, 0, (int)(GlobalSettings.SPLASHSCREEN_WIDTH / 1.5f), GlobalSettings.SPLASHSCREEN_WIDTH / 4)));

        return scene;
    }

    public static Scene LoadingScreen()
    {
        if (!_initialized)
            return new Scene();

        ContentPool.LoadLoadingScreenContent(_contentManager);

        Scene scene = new();

        scene.AddObject(
            "loadingScreen_Background1",
            new Image(
                ContentPool.Textures["loadingScreen_Background1"],
                new Rectangle(0, 0, _screenWidth, _screenHeight)));

        scene.AddObject(
            "loadingScreen_Label",
            LabelFactory.CreateLabel(
                "Loading...",
                ContentPool.Fonts["Victorian"],
                _screenWidth / 2,
                _screenHeight - 50,
                true));

        return scene;
    }

    public static Scene MainMenuScreen()
    {
        if (!_initialized)
            return new Scene();

        ContentPool.LoadMainMenuContent(_contentManager);

        Scene scene = new();

        scene.AddObject(
            "mainMenu_Background",
            new Image(
                ContentPool.Textures["mainMenu_Background"],
                new Rectangle(0, 0, _screenWidth, _screenHeight)));
        scene.AddObject(
            "mainMenu_Logo",
            new Image(
                ContentPool.Textures["gameLogo_dark"],
                new Rectangle(100, 0,
                    (int)(_screenWidth / (GlobalSettings.LOGO_SIZE_DEVIDER * 0.25f)),
                    _screenWidth / (GlobalSettings.LOGO_SIZE_DEVIDER * 2 / 3))));

        scene.AddObject("button_newGame", ButtonFactory.CreateTextButton("New Game", ContentPool.Fonts["Victorian"],
            _screenWidth - 400, _screenHeight - 500, static (_, _) => EventBus<ChangeGameStateEvent>.Raise(new ChangeGameStateEvent("inGameState"))));
        scene.AddObject("button_loadGame", ButtonFactory.CreateTextButton("Load", ContentPool.Fonts["Victorian"],
            _screenWidth - 400, _screenHeight - 430, null));
        scene.AddObject("button_settings", ButtonFactory.CreateTextButton("Settings", ContentPool.Fonts["Victorian"],
            _screenWidth - 400, _screenHeight - 360, null));
        scene.AddObject("button_extras", ButtonFactory.CreateTextButton("Extras", ContentPool.Fonts["Victorian"],
            _screenWidth - 400, _screenHeight - 290, null));
        scene.AddObject("button_credits", ButtonFactory.CreateTextButton("Credits", ContentPool.Fonts["Victorian"],
            _screenWidth - 400, _screenHeight - 220, null));
        scene.AddObject("button_quit", ButtonFactory.CreateTextButton("Quit", ContentPool.Fonts["Victorian"],
            _screenWidth - 400, _screenHeight - 150, static (_, _) => EventBus<RequestExitGameEvent>.Raise(new RequestExitGameEvent())));

        return scene;
    }
}