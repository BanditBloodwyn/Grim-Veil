using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game_IDrawable = GV.Game.IDrawable;
using IDrawable = GV.Game.IDrawable;

namespace GV.UIObjects;

public class Label : IDrawable
{
    public string Text { get; set; }
    public SpriteFont SpriteFont { get; set; }
    public Color FontColor { get; set; } = Color.White;

    public Rectangle Rectangle { get; }

    public float Rotation { get; set; } = 0;
   
    public Vector2 Scale { get; set; } = Vector2.One;

    internal Label(Rectangle rectangle)
    {
        Rectangle = rectangle;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        float textPositionX = Rectangle.X + (float)Rectangle.Width / 2 - SpriteFont.MeasureString(Text).X * Scale.X / 2;
        float textPositionY = Rectangle.Y + (float)Rectangle.Height / 2 - SpriteFont.MeasureString(Text).Y * Scale.Y / 2;
        
        spriteBatch.DrawString(
            SpriteFont,
            Text,
            new Vector2(textPositionX, textPositionY),
            FontColor,
            Rotation, Vector2.Zero, Scale, SpriteEffects.None, 0);
    }
}