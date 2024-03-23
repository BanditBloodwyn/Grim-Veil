using GV.CoreUtilities;
using GV.TypeExtentions;
using GV.WorldObjects.Tiles.TileTypes;

namespace GV.WorldManagement;

public class TileTypeManager
{
    private readonly oldTileType[] _tileTypes = TypeLoader.CreateTypeInstancesByParentType<oldTileType>();

    public oldTileType GetRandomType()
    {
        return _tileTypes.PickRandom();
    }

    public oldTileType GetByTypeName(string name)
    {
        return _tileTypes.FirstOrDefault(type => type.GetType().Name == name) ?? new AirOldTileType();
    }
}