using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game_IDrawable = GV.Game.IDrawable;
using IDrawable = GV.Game.IDrawable;

namespace GV.WorldObjects.Maps;
public class Planet : IDrawable
{
    public Rectangle Rectangle { get; }

    public void Draw(SpriteBatch spriteBatch)
    {
    }
}
