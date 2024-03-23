using Microsoft.Xna.Framework.Graphics;

namespace GV.WorldObjects.Tiles.TileTypes;

public abstract class oldTileType
{
    public abstract string Name { get; }

    public virtual Texture2D? Texture => null;

    public abstract bool IsWalkable { get; }

    public virtual bool IsAir { get; } = false;
}