using Globals.Enums;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pools;

public static class ContentPool
{
    public static Dictionary<object, Texture2D> Textures = new();
    public static Dictionary<object, SpriteFont> Fonts = new();

    public static void LoadContentByStateName(StateNames stateName, ContentManager contentManager)
    {
        switch (stateName)
        {
            case StateNames.SplashScreen:
                LoadSplashScreenContent(contentManager);
                break;
            case StateNames.StartupLoadingScreen:
                LoadStartupLoadingScreenContent(contentManager);
                break;
            case StateNames.MainMenu:
                LoadMainMenuContent(contentManager);
                break;
            case StateNames.IngameLoadingScreen:
                LoadIngameLoadingScreenContent(contentManager);
                break;
            case StateNames.Ingame_Normal:
                LoadMainGameContent(contentManager);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stateName), stateName, null);
        }
    }

    private static void LoadSplashScreenContent(ContentManager contentManager)
    {
        Textures.TryAdd("splashscreen", contentManager.Load<Texture2D>("Images/splashscreen"));
        Textures.TryAdd("gameLogo", contentManager.Load<Texture2D>("Images/logo"));

        Fonts.TryAdd("Default", contentManager.Load<SpriteFont>("Fonts/Default"));
    }

    private static void LoadStartupLoadingScreenContent(ContentManager contentManager)
    {
        Textures.TryAdd("loadingScreen_Background1", contentManager.Load<Texture2D>("Images/loadingScreen1"));
        Fonts.TryAdd("Victorian", contentManager.Load<SpriteFont>("Fonts/VictorianText"));
    }

    private static void LoadMainMenuContent(ContentManager contentManager)
    {
        Textures.TryAdd("mainMenu_Background", contentManager.Load<Texture2D>("Images/title"));
        Textures.TryAdd("Environment/Buildings/House_verylower1", contentManager.Load<Texture2D>("Environment/Buildings/House_verylower1"));
    }

    private static void LoadIngameLoadingScreenContent(ContentManager contentManager)
    {
    }

    private static void LoadMainGameContent(ContentManager contentManager)
    {

    }
}