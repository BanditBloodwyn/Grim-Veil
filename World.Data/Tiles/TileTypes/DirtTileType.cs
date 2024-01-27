using Microsoft.Xna.Framework.Graphics;
using Pools;

namespace GameObjects.World.Tiles.TileTypes;

public class DirtOldTileType : oldTileType
{
    public override string Name => "Dirt";
    public override Texture2D Texture => ResourcePool.Textures["tile_dirt"];
    public override bool IsWalkable => true;
}