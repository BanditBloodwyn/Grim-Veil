using Framework.Game;
using Framework.InputManagement;
using GameObjects.World.Extentions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Framework.Game.IDrawable;

namespace GameObjects.World.Maps;

public class EmbarkedMap(Dictionary<int, EmbarkedMapLayer> elevationLayers, int tileCountX, int tileCountY, int minimumElevationLevel, int maximumElevationLevel)
    : IDrawable, IUpdatable
{
    public Dictionary<int, EmbarkedMapLayer> ElevationLayers { get; } = elevationLayers;

    public (int, int) MapDimensions { get; } = (tileCountX, tileCountY);
    public (int, int) ElevationLevelSpan { get; } = (minimumElevationLevel, maximumElevationLevel);
    public int VisibleLayer { get; private set; }

    public Rectangle Rectangle => new(0, 0, 0, 0);

    public void Draw(SpriteBatch spriteBatch)
    {
        EmbarkedMapRenderer.Render(this, spriteBatch);
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
        if (ElevationLayers.ContainsKey(VisibleLayer + 1))
            VisibleLayer++;
    }

    public void GoLayerDown()
    {
        if (ElevationLayers.ContainsKey(VisibleLayer - 1))
            VisibleLayer--;
    }
}