using Microsoft.Xna.Framework.Graphics;
using Pools;

namespace GameObjects.World.Tiles.TileTypes;

public class StoneTileType : TileType
{
    public override string Name => "Stone";
    public override Texture2D Texture => ContentPool.Textures["tile_stone"];
    public override bool IsWalkable => true;
}