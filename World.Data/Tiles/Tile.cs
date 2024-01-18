using GameObjects.World.Tiles.TileTypes;
using Globals;
using Microsoft.Xna.Framework;

namespace GameObjects.World.Tiles;

public class Tile(TileType tileType, int coordX, int coordY)
{
    public TileType TileType { get; set; } = tileType;

    public Rectangle Rectangle { get; } = new(
        coordX, coordY,
        Settings.DEFAULT_TILE_SIZE, Settings.DEFAULT_TILE_SIZE);
}