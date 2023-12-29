using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Framework.Game.IDrawable;

namespace GameObjects.World.Maps;

public class EmbarkedMap : IDrawable
{
    private int _visibleLayer;
    
    public Dictionary<int, EmbarkedMapLayer> ElevationLayers { get; }

    public Rectangle Rectangle => new(0, 0, 0, 0);

    public EmbarkedMap(Dictionary<int, EmbarkedMapLayer> elevationLayers)
    {
        ElevationLayers = elevationLayers;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        ElevationLayers[_visibleLayer].Draw(spriteBatch);
    }

    public void GoLayerUp()
    {
        _visibleLayer++;
    }

    public void GoLayerDown()
    {
        _visibleLayer--;
    }
}