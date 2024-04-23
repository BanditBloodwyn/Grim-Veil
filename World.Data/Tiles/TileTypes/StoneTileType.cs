using GV.Pools;
using Microsoft.Xna.Framework.Graphics;

namespace GV.WorldObjects.Tiles.TileTypes;

public class StoneOldTileType : oldTileType
{
    public override string Name => "Stone";
    public override Texture2D Texture => ResourcePool.GetAsset<Texture2D>("tile_stone");
    public override bool IsWalkable => true;
}