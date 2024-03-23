using Microsoft.Xna.Framework.Graphics;

namespace Game;

public interface IDrawableIgnoreCamera
{
    public void DrawWithoutCamera(SpriteBatch spriteBatch);
}