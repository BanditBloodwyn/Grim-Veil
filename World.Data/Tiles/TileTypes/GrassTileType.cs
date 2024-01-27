using Microsoft.Xna.Framework.Graphics;
using Pools;

namespace GameObjects.World.Tiles.TileTypes;

public class GrassOldTileType : oldTileType
{
    public override string Name => "Grass";
    public override Texture2D Texture => ResourcePool.Textures["tile_grass"];
    public override bool IsWalkable => true;
}