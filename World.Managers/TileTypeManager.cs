using Core.Extentions;
using GameObjects.World.Tiles.TileTypes;

namespace World.Managers;

public class TileTypeManager
{
    private readonly TileType[] _tileTypes = TileTypeLoader.LoadAllTileTypes();
    
    public TileType GetRandomType()
    {
        return _tileTypes.PickRandom();
    }
}