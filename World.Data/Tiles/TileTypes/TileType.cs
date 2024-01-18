using Microsoft.Xna.Framework.Graphics;

namespace GameObjects.World.Tiles.TileTypes;

public abstract class TileType
{
    public abstract string Name { get; }

    public virtual Texture2D? Texture => null;

    public abstract bool IsWalkable { get; }

    public virtual bool IsAir { get; } = false;
}