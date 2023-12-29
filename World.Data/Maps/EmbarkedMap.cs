using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Framework.Game.IDrawable;

namespace GameObjects.World.Maps;

public class EmbarkedMap : IDrawable
{
    public EmbarkedMapLayer[] ElevationLayers { get; }

    public Rectangle Rectangle => new(0, 0, 0, 0);

    public EmbarkedMap(EmbarkedMapLayer[] elevationLayers)
    {
        ElevationLayers = elevationLayers;
    }

    public void Draw(SpriteBatch spriteBatch)
    {

    }
}