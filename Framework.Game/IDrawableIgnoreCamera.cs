using Microsoft.Xna.Framework.Graphics;

namespace GV.Game;

public interface IDrawableIgnoreCamera
{
    public void DrawWithoutCamera(SpriteBatch spriteBatch);
}