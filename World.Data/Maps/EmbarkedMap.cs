using GV.Game;
using GV.InputManagement;
using GV.WorldObjects.Extentions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = GV.Game.IDrawable;

namespace GV.WorldObjects.Maps;

public class EmbarkedMap(Dictionary<int, EmbarkedMapLayer> elevationLayers, int tileCountX, int tileCountY)
    : IDrawable, IUpdatable
{
    public Dictionary<int, EmbarkedMapLayer> ElevationLayers { get; } = elevationLayers;

    public (int, int) MapDimensions { get; } = (tileCountX, tileCountY);
    public (int, int) ElevationLevelSpan { get; } = (elevationLayers.Keys.Min(), elevationLayers.Keys.Max());
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