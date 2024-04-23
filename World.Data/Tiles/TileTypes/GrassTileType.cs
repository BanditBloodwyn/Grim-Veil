using GV.Pools;
using Microsoft.Xna.Framework.Graphics;

namespace GV.WorldObjects.Tiles.TileTypes;

public class GrassOldTileType : oldTileType
{
    public override string Name => "Grass";
    public override Texture2D Texture => ResourcePool.GetAsset<Texture2D>("tile_grass");
    public override bool IsWalkable => true;
}