using GameObjects.World.Tiles.TileTypes;
using Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Framework.Game.IDrawable;

namespace GameObjects.World.Tiles;

public class Tile : IDrawable
{
    public TileType TileType { get; set; }

    public Rectangle Rectangle { get; }

    public Color Tint { get; set; } = Color.White;

    public Tile(TileType tileType, int coordX, int coordY)
    {
        TileType = tileType;
        Rectangle = new Rectangle(
            coordX, coordY,
            Settings.DEFAULT_TILE_SIZE, Settings.DEFAULT_TILE_SIZE);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(TileType.Texture, Rectangle, Tint);
    }
}