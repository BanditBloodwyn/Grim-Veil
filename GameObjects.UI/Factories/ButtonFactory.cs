using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GV.UIObjects.Factories;

public static class ButtonFactory
{
    public static Button CreateTextButton(string text, SpriteFont font, int posX, int posY, Vector2 textScale, EventHandler? @event)
    {
        float width = font.MeasureString(text).X * textScale.X;
        float height = font.MeasureString(text).Y * textScale.Y;

        Button button = new(
            new Rectangle(posX, posY, (int)width, (int)height), 
            null, 
            text,
            textScale,
            font);

        if (@event != null)
            button.Clicked += @event;

        return button;
    }
}