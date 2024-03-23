using GV.Globals;
using GV.WorldObjects.Tiles.TileTypes;
using Microsoft.Xna.Framework;

namespace GV.WorldObjects.Tiles;

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