using Microsoft.Xna.Framework.Graphics;
using Pools;

namespace GameObjects.World.Tiles.TileTypes;

public class GrassTileType : TileType
{
    public override string Name => "Grass";
    public override Texture2D Texture => ContentPool.Textures["tile_grass"];
    public override bool IsWalkable => true;
}