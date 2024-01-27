using Globals.World;
using Microsoft.Xna.Framework.Content;

namespace Pools;

public static class ContentPool
{
    private static ContentManager? _contentManager;

    public static Dictionary<object, TileType> TileTypes = new();

    public static void Initialize(ContentManager content)
    {
        _contentManager = content;
    }

    public static void LoadTileTypes()
    {
        if (_contentManager == null)
            return;

        TileTypes.TryAdd("dirt", _contentManager.Load<TileType>("JSON/TileTypes/tileType_dirt"));
    }
}