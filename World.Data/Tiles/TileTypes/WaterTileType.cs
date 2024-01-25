using Microsoft.Xna.Framework.Graphics;
using Pools;

namespace GameObjects.World.Tiles.TileTypes;

public class WaterTileType : TileType
{
    public override string Name => "Water";
    public override Texture2D Texture => ResourcePool.Textures["tile_water"];
    public override bool IsWalkable => false;
}