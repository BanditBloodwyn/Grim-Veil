using GameEvents;
using GV.EventBus;
using GV.Globals;
using GV.Globals.Enums;
using GV.Pools;
using GV.UIObjects;
using GV.UIObjects.Factories;
using GV.WorldManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace GV.SceneManagement;

public class SceneBuilder
{
    private static readonly int _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    private static readonly int _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

    public static bool TryBuildByName(SceneNames stateName, out Scene? scene)
    {
        ResourcePool.LoadContentByStateName(stateName);
        ContentPool.LoadContentByStateName(stateName);

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
        Scene scene = new();
        scene.Name = "Splash Screen Scene";

        Image background = new Image(new Rectangle(0, 0, Settings.SPLASHSCREEN_WIDTH, Settings.SPLASHSCREEN_HEIGHT));
        background.Texture = ResourcePool.Textures["splashscreen"];
        scene.AddObject(
            "background",
            background);

        Image logo = new Image(new Rectangle(Settings.SPLASHSCREEN_WIDTH / 4, 0, Settings.SPLASHSCREEN_WIDTH / 2, Settings.SPLASHSCREEN_WIDTH / 2));
        logo.Texture = ResourcePool.Textures["gameLogo"];
        scene.AddObject(
            "logo",
            logo);

        return scene;
    }

    private static Scene StartupLoadingScreen()
    {
        Scene scene = new();
        scene.Name = "Startup Loading Screen Scene";

        Image background = new Image(new Rectangle(0, 0, _screenWidth, _screenHeight));
        background.Texture = ResourcePool.Textures["loadingScreen_Background1"];

        scene.AddObject(
            "loadingScreen_Background1",
            background);

        scene.AddObject(
            "loadingScreen_Label",
            LabelFactory.CreateLabel(
                "Loading...",
                ResourcePool.Fonts["Default"],
                _screenWidth / 2,
                _screenHeight - 50,
                true));

        return scene;
    }

    private static Scene MainMenuScreen()
    {
        Scene scene = new();
        scene.Name = "Main Menu Scene";

        Image background = new Image(new Rectangle(0, 0, _screenWidth, _screenHeight));
        background.Texture = ResourcePool.Textures["mainMenu_Background"];
        scene.AddObject("mainMenu_Background", background);

        Image logo = new Image(new Rectangle(30, 10,
                _screenWidth / Settings.LOGO_SIZE_DEVIDER * 3,
                _screenWidth / Settings.LOGO_SIZE_DEVIDER * 3));
        logo.Texture = ResourcePool.Textures["gameLogo"];
        scene.AddObject("mainMenu_Logo", logo);

        SpriteFont font = ResourcePool.Fonts["Default"];
        scene.AddObject("button_newGame", ButtonFactory.CreateTextButton("New Game", font,
            _screenWidth - 400, _screenHeight - 500, new Vector2(3), static (_, _) => EventBus<ChangeGameStateEvent>.Raise(new ChangeGameStateEvent(StateNames.Ingame_Normal))));
        scene.AddObject("button_loadGame", ButtonFactory.CreateTextButton("Load", font,
            _screenWidth - 400, _screenHeight - 430, new Vector2(3), null));
        scene.AddObject("button_settings", ButtonFactory.CreateTextButton("Settings", font,
            _screenWidth - 400, _screenHeight - 360, new Vector2(3), null));
        scene.AddObject("button_extras", ButtonFactory.CreateTextButton("Extras", font,
            _screenWidth - 400, _screenHeight - 290, new Vector2(3), null));
        scene.AddObject("button_credits", ButtonFactory.CreateTextButton("Credits", font,
            _screenWidth - 400, _screenHeight - 220, new Vector2(3), null));
        scene.AddObject("button_quit", ButtonFactory.CreateTextButton("Quit", font,
            _screenWidth - 400, _screenHeight - 150, new Vector2(3), static (_, _) => EventBus<RequestExitGameEvent>.Raise(new RequestExitGameEvent())));

        return scene;
    }

    private static Scene IngameLoadingScreen()
    {
        Scene scene = new();
        scene.Name = "InGame Loading Screen Scene";

        return scene;
    }

    private static Scene InGameScene()
    {
        Scene scene = new();
        scene.Name = "InGame Scene";

        EmbarkedMapBuilder embarkedMapBuilder = new(
            new TileTypeManager());

        scene.AddObject("map",
            embarkedMapBuilder.Build(40, 20, -10, 10));

        return scene;
    }
}