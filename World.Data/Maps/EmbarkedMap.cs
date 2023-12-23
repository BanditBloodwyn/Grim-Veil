using Framework.Game;
using GameObjects.World.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Framework.Game.IDrawable;

namespace GameObjects.World.Maps;

public class EmbarkedMap : IUpdatable, IDrawable
{
    private Tile[,,] Tiles { get; } // 3D array for the tiles

    public Rectangle Rectangle => new(0, 0, 0, 0);

    public int ElevationLevelInView { get; set; }

    public EmbarkedMap(Tile[,,] tiles)
    {
        Tiles = tiles;
    }

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < Tiles.GetLength(0); i++)
            for (int j = 0; j < Tiles.GetLength(1); j++)
                Tiles[i, j, ElevationLevelInView].Draw(spriteBatch);
    }
}