using Core.Extentions;
using Core.Utilities;
using GameObjects.World.Tiles.TileTypes;

namespace World.Managers;

public class TileTypeManager
{
    private readonly TileType[] _tileTypes = TypeLoader.CreateTypeInstancesByParentType<TileType>();

    public TileType GetRandomType()
    {
        return _tileTypes.PickRandom();
    }
}