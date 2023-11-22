using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pools;

public static class ContentPool
{
    public static Dictionary<object, Texture2D> Textures = new();
    public static Dictionary<object, SpriteFont> Fonts = new();

    public static void LoadSplashScreenContent(ContentManager contentManager)
    {
        Textures.Add("splashscreen", contentManager.Load<Texture2D>("Images/splashscreen"));
        Textures.Add("gameLogo", contentManager.Load<Texture2D>("Images/logo"));
    }
    public static void LoadContent(ContentManager contentManager)
    {
        Textures.Add("gameLogo_dark", contentManager.Load<Texture2D>("Images/logo_dark"));
        Textures.Add("mainMenu_Background", contentManager.Load<Texture2D>("Images/title"));
     
        Textures.Add("Environment/Buildings/House_verylower1", contentManager.Load<Texture2D>("Environment/Buildings/House_verylower1"));

        Fonts.Add("Victorian", contentManager.Load<SpriteFont>("Fonts/VictorianText"));
    }
}