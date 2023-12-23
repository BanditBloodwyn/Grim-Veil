using GameObjects.World.Maps;
using GameObjects.World.Tiles;
using Globals;

namespace World.Managers;

public class EmbarkedMapBuilder
{
    private readonly TileTypeManager tileTypeManager;

    public EmbarkedMapBuilder(TileTypeManager tileTypeManager)
    {
        this.tileTypeManager = tileTypeManager;
    }

    public EmbarkedMap Build(
        int tileCountX,
        int tileCountY,
        int minimumElevationLevel,
        int maximumElevationLevel)
    {
        return new EmbarkedMap(
            InitializeTiles(tileCountX, tileCountY, minimumElevationLevel, maximumElevationLevel));
    }

    public Tile[,,] InitializeTiles(
        int tileCountX,
        int tileCountY,
        int minimumElevationLevel,
        int maximumElevationLevel)
    {
        int elevationLevelCount = maximumElevationLevel - minimumElevationLevel;

        Tile[,,] tiles = new Tile[tileCountX, tileCountY, elevationLevelCount];

        for (int x = 0; x < tiles.GetLength(0); x++)
            for (int y = 0; y < tiles.GetLength(1); y++)
                for (int z = 0; z < tiles.GetLength(2); z++)
                    tiles[x, y, z] = new Tile(
                        tileTypeManager.GetRandomType(),
                        x * Settings.DEFAULT_TILE_SIZE,
                        y * Settings.DEFAULT_TILE_SIZE,
                        z);

        return tiles;
    }

}