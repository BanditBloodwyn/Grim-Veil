using GameObjects.World.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Framework.Game.IDrawable;

namespace GameObjects.World.Maps;

public class EmbarkedMapLayer : IDrawable
{
    public Tile[,] Tiles { get; } // 2D array for the tiles

    public int ElevationLevel { get; }

    public Rectangle Rectangle => new(0, 0, 0, 0);

    public EmbarkedMapLayer(Tile[,] tiles, int elevationLevel)
    {
        Tiles = tiles;
        ElevationLevel = elevationLevel;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < Tiles.GetLength(0); i++)
            for (int j = 0; j < Tiles.GetLength(1); j++)
                Tiles[i, j].Draw(spriteBatch);
    }
}