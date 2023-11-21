using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GrimVeil.Utilities;

public static class ContentLoader
{
    public static Dictionary<object, Texture2D> Textures = new();
    public static void LoadContent(ContentManager contentManager)
    {
        Textures.Add("Environment/Buildings/House_verylower1", contentManager.Load<Texture2D>("Environment/Buildings/House_verylower1"));
        Textures.Add("splashscreen", contentManager.Load<Texture2D>("Images/splashscreen"));
    }
}