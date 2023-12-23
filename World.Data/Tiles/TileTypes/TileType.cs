using Microsoft.Xna.Framework.Graphics;

namespace GameObjects.World.Tiles.TileTypes;

public abstract class TileType
{
    public abstract string Name { get; }

    public abstract Texture2D Texture { get; }

    public abstract bool IsWalkable { get; }
}