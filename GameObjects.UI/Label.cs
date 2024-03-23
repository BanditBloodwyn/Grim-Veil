using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game_IDrawable = Game.IDrawable;

namespace GV.UIObjects;

public class Label : Game_IDrawable
{
    public string Text { get; set; }
    public SpriteFont SpriteFont { get; set; }
    public Color FontColor { get; set; } = Color.White;

    public Rectangle Rectangle { get; }

    public Label(string text, SpriteFont spriteFont, Rectangle rectangle)
    {
        Text = text;
        SpriteFont = spriteFont;
        Rectangle = rectangle;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        float textPositionX = Rectangle.X + (float)Rectangle.Width / 2 - SpriteFont.MeasureString(Text).X / 2;
        float textPositionY = Rectangle.Y + (float)Rectangle.Height / 2 - SpriteFont.MeasureString(Text).Y / 2;
        
        spriteBatch.DrawString(
            SpriteFont,
            Text,
            new Vector2(textPositionX, textPositionY),
            FontColor);
    }
}