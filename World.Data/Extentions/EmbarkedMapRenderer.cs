using GameObjects.World.Maps;
using GameObjects.World.Tiles;
using GameObjects.World.Tiles.TileTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameObjects.World.Extentions;

public static class EmbarkedMapRenderer
{
    public static void Render(EmbarkedMap map, SpriteBatch spriteBatch)
    {
        for (int x = 0; x < map.MapDimensions.Item1; x++)
        {
            for (int y = 0; y < map.MapDimensions.Item2; y++)
            {
                if (!TryGetTileToRender(map, x, y, map.VisibleLayer, out Tile? tileToRender, out int tintValue))
                    continue;

                if (tileToRender == null)
                    continue;

                spriteBatch.Draw(
                    tileToRender.TileType.Texture,
                    tileToRender.Rectangle,
                    new Color(tintValue, tintValue, tintValue));
            }
        }
    }

    private static bool TryGetTileToRender(EmbarkedMap map, int x, int y, int layer, out Tile? tile, out int tintValue, int recursionDepth = 1)
    {
        tile = null;
        tintValue = 255;

        Tile tileToRender = map.ElevationLayers[layer].Tiles[x, y];

        if (tileToRender.TileType is not AirOldTileType)
        {
            tile = tileToRender;
            tintValue = 255 / recursionDepth;
            return true;
        }

        if (layer - 1 < map.ElevationLevelSpan.Item1)
            return false;

        return TryGetTileToRender(map, x, y, layer - 1, out tile, out tintValue, recursionDepth + 1);
    }
}