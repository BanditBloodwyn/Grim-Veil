using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Framework.Game.IDrawable;

namespace GameObjects.UI;

public class Image : IDrawable
{
    private readonly Texture2D _texture; 
    
    public Color Tint { get; set; }
    public Rectangle Rectangle { get; }

    public Image(Texture2D texture, Rectangle rectangle, Color? tint = null)
    {
        _texture = texture;
        Rectangle = rectangle;
        Tint = tint ?? Color.White;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            _texture,
            Rectangle,
            Tint);
    }
}