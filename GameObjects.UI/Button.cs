using Game;
using InputManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game_IDrawable = Game.IDrawable;

namespace GV.UIObjects;

public class Button : IUpdatable, Game_IDrawable
{
    private readonly Image _background;
    private readonly Label? _label;

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

    internal Button(Rectangle rectangle, Texture2D? background = null, string? text = null, Vector2? textScale = null, SpriteFont? spriteFont = null)
    {
        Rectangle = rectangle;

        _background = new Image(Rectangle);

        if (background != null)
            _background.Texture = background;

        if (!string.IsNullOrEmpty(text) && spriteFont != null)
        {
            _label = new Label(Rectangle);
            _label.Text = text;
            _label.SpriteFont = spriteFont;
            _label.Scale = textScale ?? Vector2.One;
        }
    }

    public void Update(GameTime gameTime)
    {
        MouseState currentMouseState = InputManager.GetCurrentMouseState();

        Rectangle mouseRectangle = new(currentMouseState.X, currentMouseState.Y, 1, 1);
        _isMouseOver = mouseRectangle.Intersects(Rectangle);

        if (_isMouseOver)
        {
            _isMousePressed = currentMouseState.LeftButton == ButtonState.Pressed;

            if (InputManager.IsLeftMouseButtonClicked())
                Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (_isMouseOver)
        {
            _background.Tint = _isMousePressed
                ? MousePressTint
                : MouseOverTint;
        }
        else
            _background.Tint = NormalTint;

        _background.Draw(spriteBatch);

        if (_label == null)
            return;

        if (_isMouseOver)
        {
            _label.FontColor = _isMousePressed
                ? MousePressFontColor
                : MouseOverFontColor;
        }
        else
            _label.FontColor = NormalFontColor;

        _label.Draw(spriteBatch);
    }
}