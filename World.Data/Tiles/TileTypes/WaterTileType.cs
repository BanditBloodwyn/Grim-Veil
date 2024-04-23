using GV.Pools;
using Microsoft.Xna.Framework.Graphics;

namespace GV.WorldObjects.Tiles.TileTypes;

public class WaterOldTileType : oldTileType
{
    public override string Name => "Water";
    public override Texture2D Texture => ResourcePool.GetAsset<Texture2D>("tile_water");
    public override bool IsWalkable => false;
}