using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pools;

public static class ContentPool
{
    public static Dictionary<object, Texture2D> Textures = new();
    public static Dictionary<object, SpriteFont> Fonts = new();

    public static void LoadSplashScreenContent(ContentManager contentManager)
    {
        Textures.TryAdd("splashscreen", contentManager.Load<Texture2D>("Images/splashscreen"));
        Textures.TryAdd("gameLogo", contentManager.Load<Texture2D>("Images/logo"));
      
        Fonts.TryAdd("Default", contentManager.Load<SpriteFont>("Fonts/Default"));
    }

    public static void LoadLoadingScreenContent(ContentManager contentManager)
    {
        Textures.TryAdd("loadingScreen_Background1", contentManager.Load<Texture2D>("Images/loadingScreen1"));
        Fonts.TryAdd("Victorian", contentManager.Load<SpriteFont>("Fonts/VictorianText"));
    }

    public static void LoadMainMenuContent(ContentManager contentManager)
    {
        Textures.TryAdd("gameLogo_dark", contentManager.Load<Texture2D>("Images/logo_dark"));
        Textures.TryAdd("mainMenu_Background", contentManager.Load<Texture2D>("Images/title"));
        
        Textures.TryAdd("Environment/Buildings/House_verylower1", contentManager.Load<Texture2D>("Environment/Buildings/House_verylower1"));
    }

    public static void LoadMainGameContent(ContentManager contentManager)
    {

    }
}