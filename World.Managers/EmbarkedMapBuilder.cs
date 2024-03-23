using GameObjects.World.Maps;
using GameObjects.World.Tiles;
using GameObjects.World.Tiles.TileTypes;
using Globals;

namespace World.Managers;

public class EmbarkedMapBuilder
{
    private readonly TileTypeManager _tileTypeManager;
    
    public EmbarkedMapBuilder(TileTypeManager tileTypeManager)
    {
        _tileTypeManager = tileTypeManager;
    }

    public EmbarkedMap Build(
        int tileCountX,
        int tileCountY,
        int minimumElevationLevel,
        int maximumElevationLevel)
    {
        Dictionary<int, EmbarkedMapLayer> layers = CreateLayers(tileCountX, tileCountY, minimumElevationLevel, maximumElevationLevel)
            .ToDictionary(static layer => layer.ElevationLevel, static layer => layer);

        return new EmbarkedMap(layers, tileCountX, tileCountY);
    }

    private IEnumerable<EmbarkedMapLayer> CreateLayers(
        int tileCountX,
        int tileCountY,
        int minimumElevationLevel,
        int maximumElevationLevel)
    {
        for (int elevationLevel = minimumElevationLevel; elevationLevel < maximumElevationLevel; elevationLevel++)
        {
            Tile[,] tiles = CreateTiles(tileCountX, tileCountY, elevationLevel);
            EmbarkedMapLayer layer = new(tiles, elevationLevel);
            yield return layer;
        }
    }

    private Tile[,] CreateTiles(int tileCountX, int tileCountY, int elevationLevel)
    {
        Tile[,] tiles = new Tile[tileCountX, tileCountY];

        for (int x = 0; x < tiles.GetLength(0); x++)
            for (int y = 0; y < tiles.GetLength(1); y++)
                tiles[x, y] = new Tile(
                    GetTileType(elevationLevel),
                    x * Settings.DEFAULT_TILE_SIZE,
                    y * Settings.DEFAULT_TILE_SIZE);

        return tiles;
    }

    private oldTileType GetTileType(int elevationLevel)
    {
        if (elevationLevel > 0)
            return _tileTypeManager.GetByTypeName("AirOldTileType");
        if (elevationLevel == 0)
            return _tileTypeManager.GetByTypeName("GrassOldTileType");

        return _tileTypeManager.GetByTypeName("DirtOldTileType");
    }
}