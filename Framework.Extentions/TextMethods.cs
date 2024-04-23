using GV.Pools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GV.Extentions;
public static class TextMethods
{
    public static int WriteDefaultString(this SpriteBatch spriteBatch, string text, int posX, int posY)
    {
        spriteBatch.DrawString(ResourcePool.GetAsset<SpriteFont>("default"), text, new Vector2(posX, posY), Color.White);
        
        return (int)ResourcePool.GetAsset<SpriteFont>("default").MeasureString(text).Y;
    }
}
