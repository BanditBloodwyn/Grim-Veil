using GameObjects.World.Tiles.TileTypes;
using Globals;
using Microsoft.Xna.Framework;

namespace GameObjects.World.Tiles;

public class Tile
{
    public oldTileType TileType { get; set; }

    public Rectangle Rectangle { get; }

    public Tile(oldTileType tileType, int coordX, int coordY)
    {
        TileType = tileType;
        Rectangle = new(
            coordX, coordY,
            Settings.DEFAULT_TILE_SIZE, Settings.DEFAULT_TILE_SIZE);
    }
}