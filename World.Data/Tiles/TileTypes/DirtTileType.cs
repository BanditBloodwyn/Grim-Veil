using GV.Pools;
using Microsoft.Xna.Framework.Graphics;

namespace GV.WorldObjects.Tiles.TileTypes;

public class DirtOldTileType : oldTileType
{
    public override string Name => "Dirt";
    public override Texture2D Texture => ResourcePool.GetAsset<Texture2D>("tile_dirt");
    public override bool IsWalkable => true;
}