﻿using Core.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IDrawable = Core.Game.IDrawable;

namespace UI.Core
{
    public class Button : IUpdatable, IDrawable
    {
        private readonly Image? _background;
        private readonly Label? _label;

        private MouseState _currentMouseState;
        private MouseState _previousMouseState;
        private bool _isMouseOver;
       
        public Rectangle Rectangle { get; }
        
        public Color NormalFontColor { get; set; } = Color.White;
       
        public Color MouseOverFontColor { get; set; } = Color.Gray;

        public Color NormalTint { get; set; } = Color.White;

        public Color MouseOverTint { get; set; } = Color.LightGray;

        public bool IsClicked { get; private set; }

        public event EventHandler? Clicked;

        public Button(Rectangle rectangle, Texture2D? background = null, string? text = null, SpriteFont? spriteFont = null)
        {
            Rectangle = rectangle;

            if (background != null)
                _background = new Image(
                    background,
                    Rectangle);

            if (!string.IsNullOrEmpty(text) && spriteFont != null)
                _label = new Label(text, spriteFont, rectangle);
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

            if (_label != null)
            {
                _label.FontColor = _isMouseOver 
                    ? MouseOverFontColor 
                    : NormalFontColor;
                _label.Draw(spriteBatch, gameTime);
            }
        }
    }
}
