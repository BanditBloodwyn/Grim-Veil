using Core.Patterns.Behaviours.EventBus;
using Framework.GameEvents;
using GameObjects.UI;
using GameObjects.UI.Factories;
using Globals;
using Globals.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using System.Diagnostics;
using World.Managers;

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

    public static bool TryBuildByName(SceneNames stateName, out Scene? scene)
    {
        ContentPool.LoadContentByStateName(stateName, _contentManager);

        scene = stateName switch
        {
            SceneNames.SplashScreen => SplashScreen(),
            SceneNames.StartupLoadingScreen => StartupLoadingScreen(),
            SceneNames.MainMenu => MainMenuScreen(),
            SceneNames.IngameLoadingScreen => IngameLoadingScreen(),
            SceneNames.Ingame_Normal => InGameScene(),
            _ => null
        };

        if (scene == null)
            Debug.WriteLine("Scene unknown!");

        return scene != null;
    }

    private static Scene SplashScreen()
    {
        if (!_initialized)
            return new Scene();

        Scene scene = new();
        scene.Name = "Splash Screen Scene";

        scene.AddObject(
            "background",
            new Image(
                ContentPool.Textures["splashscreen"],
                new Rectangle(0, 0, Settings.SPLASHSCREEN_WIDTH, Settings.SPLASHSCREEN_HEIGHT)));
        scene.AddObject(
            "logo",
            new Image(
                ContentPool.Textures["gameLogo"],
                new Rectangle(Settings.SPLASHSCREEN_WIDTH / 4, 0,
                    Settings.SPLASHSCREEN_WIDTH / 2,
                    Settings.SPLASHSCREEN_WIDTH / 2)));

        return scene;
    }

    private static Scene StartupLoadingScreen()
    {
        if (!_initialized)
            return new Scene();

        Scene scene = new();
        scene.Name = "Startup Loading Screen Scene";

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

    private static Scene MainMenuScreen()
    {
        if (!_initialized)
            return new Scene();

        Scene scene = new();
        scene.Name = "Main Menu Scene";

        scene.AddObject(
            "mainMenu_Background",
            new Image(
                ContentPool.Textures["mainMenu_Background"],
                new Rectangle(0, 0, _screenWidth, _screenHeight)));
        scene.AddObject(
            "mainMenu_Logo",
            new Image(
                ContentPool.Textures["gameLogo"],
                new Rectangle(30, 10,
                    _screenWidth / Settings.LOGO_SIZE_DEVIDER * 3,
                    _screenWidth / Settings.LOGO_SIZE_DEVIDER * 3)));

        scene.AddObject("button_newGame", ButtonFactory.CreateTextButton("New Game", ContentPool.Fonts["Victorian"],
            _screenWidth - 400, _screenHeight - 500, static (_, _) => EventBus<ChangeGameStateEvent>.Raise(new ChangeGameStateEvent(StateNames.Ingame_Normal))));
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

    private static Scene IngameLoadingScreen()
    {
        if (!_initialized)
            return new Scene();

        Scene scene = new();
        scene.Name = "InGame Loading Screen Scene";

        return scene;
    }

    private static Scene InGameScene()
    {
        if (!_initialized)
            return new Scene();

        Scene scene = new();
        scene.Name = "InGame Scene";

        EmbarkedMapBuilder embarkedMapBuilder = new(
            new TileTypeManager());

        scene.AddObject("map",
            embarkedMapBuilder.Build(40, 20, -10, 10));

        return scene;
    }
}