using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Framework.Game.IDrawable;

namespace GameObjects.World.Maps;
public class Planet : IDrawable
{
    public Rectangle Rectangle { get; }

    public void Draw(SpriteBatch spriteBatch)
    {
    }
}
