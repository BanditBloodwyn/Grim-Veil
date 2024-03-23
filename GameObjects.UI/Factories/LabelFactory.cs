using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GV.UIObjects.Factories;

public static class LabelFactory
{
    public static Label CreateLabel(string text, SpriteFont font, int posX, int posY, bool useCenterAsPosition = false)
    {
        Vector2 stringSize = font.MeasureString(text);

        Rectangle rect = useCenterAsPosition
            ? new Rectangle(posX - (int)(stringSize.X / 2), (int)(posY - stringSize.Y / 2), (int)stringSize.X, (int)stringSize.Y)
            : new Rectangle(posX, posY, (int)stringSize.X, (int)stringSize.Y);

        Label label = new(text, font, rect);

        return label;
    }

}