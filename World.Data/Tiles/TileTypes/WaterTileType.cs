using Microsoft.Xna.Framework.Graphics;
using Pools;

namespace GameObjects.World.Tiles.TileTypes;

public class WaterOldTileType : oldTileType
{
    public override string Name => "Water";
    public override Texture2D Texture => ResourcePool.Textures["tile_water"];
    public override bool IsWalkable => false;
}