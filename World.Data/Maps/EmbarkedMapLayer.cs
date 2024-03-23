using GV.WorldObjects.Tiles;

namespace GV.WorldObjects.Maps;

public class EmbarkedMapLayer
{
    public Tile[,] Tiles { get; } // 2D array for the tiles

    public int ElevationLevel { get; }

    public EmbarkedMapLayer(Tile[,] tiles, int elevationLevel)
    {
        Tiles = tiles;
        ElevationLevel = elevationLevel;
    }
}