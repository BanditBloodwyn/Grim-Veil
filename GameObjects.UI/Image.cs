using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = GV.Game.IDrawable;

namespace GV.UIObjects;

public class Image(Rectangle rectangle) : IDrawable
{
    public Color Tint { get; set; } = Color.White;
    public Texture2D? Texture { get; set; } = null;
    public Rectangle Rectangle { get; } = rectangle;

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