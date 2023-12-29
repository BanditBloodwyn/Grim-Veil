using Microsoft.Xna.Framework.Graphics;

namespace Framework.Game;

public interface IDrawableIgnoreCamera
{
    public void DrawWithoutCamera(SpriteBatch spriteBatch);
}