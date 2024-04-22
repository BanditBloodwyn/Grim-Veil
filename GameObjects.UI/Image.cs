using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game_IDrawable = Game.IDrawable;

namespace GV.UIObjects;

public class Image : Game_IDrawable
{
    public Color Tint { get; set; } = Color.White;
    public Texture2D? Texture { get; set; } = null;
    public Rectangle Rectangle { get; }

    public Image(Rectangle rectangle)
    {
        Rectangle = rectangle;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (Texture == null)
            return;

        spriteBatch.Draw(
            Texture,
            Rectangle,
            Tint);
    }
}