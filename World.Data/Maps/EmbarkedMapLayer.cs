using GameObjects.World.Tiles;

namespace GameObjects.World.Maps;

public class EmbarkedMapLayer(Tile[,] tiles, int elevationLevel)
{
    public Tile[,] Tiles { get; } = tiles; // 2D array for the tiles

    public int ElevationLevel { get; } = elevationLevel;
}