using Core.Extentions;
using Core.Utilities;
using GameObjects.World.Tiles.TileTypes;

namespace World.Managers;

public class TileTypeManager
{
    private readonly oldTileType[] _tileTypes = TypeLoader.CreateTypeInstancesByParentType<oldTileType>();

    public oldTileType GetRandomType()
    {
        return _tileTypes.PickRandom();
    }
}