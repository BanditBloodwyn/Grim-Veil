using Framework.Game;
using Framework.InputManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Framework.Game.IDrawable;

namespace GameObjects.World.Maps;

public class EmbarkedMap : IDrawable, IUpdatable
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

    public void Update(GameTime gameTime)
    {
        if (InputManager.IsControlHeld())
        {
            float mouseWheelDelta = InputManager.MouseWheelDelta();

            if (mouseWheelDelta > 0)
                GoLayerUp();
            if (mouseWheelDelta < 0)
                GoLayerDown();
        }
    }

    public void GoLayerUp()
    {
        if (ElevationLayers.ContainsKey(_visibleLayer + 1))
            _visibleLayer++;
    }

    public void GoLayerDown()
    {
        if (ElevationLayers.ContainsKey(_visibleLayer - 1))
            _visibleLayer--;
    }
}