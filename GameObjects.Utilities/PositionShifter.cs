using Microsoft.Xna.Framework;

namespace GameObjects.Utilities
{
    public static class PositionShifter
    {
        public static Rectangle GetShiftedRectangle(Rectangle rectangle)
        {
            return new Rectangle(
                rectangle.Location + Camera.Instance.Position, 
                rectangle.Size);
        }
    }
}
