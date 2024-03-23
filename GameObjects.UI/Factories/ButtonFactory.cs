using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GV.UIObjects.Factories;

public static class ButtonFactory
{
    public static Button CreateTextButton(string text, SpriteFont font, int posX, int posY, EventHandler? @event)
    {
        Button button = new(
            new Rectangle(posX, posY, (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y), 
            null, 
            text, 
            font);

        if (@event != null)
            button.Clicked += @event;

        return button;
    }
}