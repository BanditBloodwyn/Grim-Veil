using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Game;

public interface IDrawable
{
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
}