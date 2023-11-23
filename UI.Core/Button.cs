using Core.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IDrawable = Core.Game.IDrawable;

namespace UI.Core
{
    public class Button : IUpdatable, IDrawable
    {
        private readonly Image? _background;

        private MouseState _currentMouseState;
        private MouseState _previousMouseState;
        private bool _isMouseOver;
       
        public Rectangle Rectangle { get; }
       
        public string? Text { get; set; }
       
        public SpriteFont? SpriteFont { get; set; }
        
        public Color NormalFontColor { get; set; } = Color.White;
       
        public Color MouseOverFontColor { get; set; } = Color.LightGray;

        public Color NormalTint { get; set; } = Color.White;

        public Color MouseOverTint { get; set; } = Color.Gray;

        public bool IsClicked { get; private set; }

        public event EventHandler? Clicked;

        public Button(Rectangle rectangle, Texture2D? background = null)
        {
            Rectangle = rectangle;

            if (background != null)
                _background = new Image(
                    background,
                    Rectangle);
        }
        public void Update(GameTime gameTime)
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            Rectangle mouseRectangle = new(_currentMouseState.X, _currentMouseState.Y, 1, 1);

            _isMouseOver = mouseRectangle.Intersects(Rectangle);

            if (_isMouseOver
                && _currentMouseState.LeftButton == ButtonState.Released
                && _previousMouseState.LeftButton == ButtonState.Pressed)
            {
                Clicked?.Invoke(this, EventArgs.Empty);
            }

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (_background != null)
            {
                _background.Tint = _isMouseOver
                    ? MouseOverTint
                    : NormalTint;
                _background.Draw(spriteBatch, gameTime);
            }

            if(string.IsNullOrEmpty(Text) || SpriteFont == null)
                return;

            float textPositionX = (Rectangle.X + (float)Rectangle.Width / 2) - SpriteFont.MeasureString(Text).X / 2;
            float textPositionY = (Rectangle.Y + (float)Rectangle.Height / 2) - SpriteFont.MeasureString(Text).Y / 2;

            spriteBatch.DrawString(
                SpriteFont, 
                Text, 
                new Vector2(textPositionX, textPositionY), 
                _isMouseOver ? MouseOverFontColor : NormalFontColor);
        }
    }
}
