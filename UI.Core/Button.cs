using Core.Game;
using Managers.InputManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IDrawable = Core.Game.IDrawable;

namespace UI.Core;

public class Button : IUpdatable, IDrawable
{
    private readonly Image? _background;
    private readonly Label? _label;
    private readonly InputManager _inputManager = new();

    private bool _isMouseOver;
    private bool _isMousePressed;

    public Rectangle Rectangle { get; }

    public Color NormalFontColor { get; set; } = Color.White;
    public Color MouseOverFontColor { get; set; } = Color.Gray;
    public Color MousePressFontColor { get; set; } = Color.DarkGray;

    public Color NormalTint { get; set; } = Color.White;
    public Color MouseOverTint { get; set; } = Color.LightGray;
    public Color MousePressTint { get; set; } = Color.LightGray;

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
        _inputManager.Update(gameTime);
        MouseState currentMouseState = _inputManager.GetCurrentMouseState();

        Rectangle mouseRectangle = new(currentMouseState.X, currentMouseState.Y, 1, 1);
        _isMouseOver = mouseRectangle.Intersects(Rectangle);

        if (_isMouseOver)
        {
            _isMousePressed = currentMouseState.LeftButton == ButtonState.Pressed;

            if (_inputManager.IsLeftMouseButtonClicked())
                Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        if (_background != null)
        {
            if (_isMouseOver)
            {
                _background.Tint = _isMousePressed
                    ? MousePressTint
                    : MouseOverTint;
            }
            else
                _background.Tint = NormalTint;

            _background.Draw(spriteBatch, gameTime);
        }

        if (_label != null)
        {
            if (_isMouseOver)
            {
                _label.FontColor = _isMousePressed
                    ? MousePressFontColor
                    : MouseOverFontColor;
            }
            else
                _label.FontColor = NormalFontColor;

            _label.Draw(spriteBatch, gameTime);
        }
    }
}