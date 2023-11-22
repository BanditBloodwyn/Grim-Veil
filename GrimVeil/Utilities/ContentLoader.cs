using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GrimVeil.Utilities;

public static class ContentLoader
{
    public static Dictionary<object, Texture2D> Textures = new();
    public static Dictionary<object, SpriteFont> Fonts = new();

    public static void LoadContent(ContentManager contentManager)
    {
        Textures.Add("splashscreen", contentManager.Load<Texture2D>("Images/splashscreen"));
        Textures.Add("gameLogo", contentManager.Load<Texture2D>("Images/logo"));
        Textures.Add("gameLogo_dark", contentManager.Load<Texture2D>("Images/logo_dark"));
        Textures.Add("mainMenu_Background", contentManager.Load<Texture2D>("Images/title"));
     
        Textures.Add("Environment/Buildings/House_verylower1", contentManager.Load<Texture2D>("Environment/Buildings/House_verylower1"));

        Fonts.Add("Victorian", contentManager.Load<SpriteFont>("Fonts/VictorianText"));
    }
}