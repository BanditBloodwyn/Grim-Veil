using Core.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Core.Game.IDrawable;

namespace UI.Core
{
    public class Button : IUpdatable, IDrawable
    {
        public Rectangle Rectangle { get; }

        public Button(string text, Rectangle rectangle)
        {
            Rectangle = rectangle;
        }
        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }
    }
}
