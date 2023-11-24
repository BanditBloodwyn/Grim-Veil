using Core.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Managers.InputManagement;
public class InputManager : IUpdatable
{
    private KeyboardState _currentKeyboardState;
    private KeyboardState _previousKeyboardState;
    private MouseState _currentMouseState;
    private MouseState _previousMouseState;

    public InputManager()
    {
        _currentKeyboardState = Keyboard.GetState();
        _previousKeyboardState = _currentKeyboardState;
        _currentMouseState = Mouse.GetState();
        _previousMouseState = _currentMouseState;
    }

    public void Update(GameTime gameTime)
    {
        _previousKeyboardState = _currentKeyboardState;
        _currentKeyboardState = Keyboard.GetState();
        _previousMouseState = _currentMouseState;
        _currentMouseState = Mouse.GetState();
    }

    public MouseState GetCurrentMouseState() => _currentMouseState;

    public bool IsKeyPressed(Keys key) => _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
    public bool IsKeyHeld(Keys key) => _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyDown(key);
    public bool IsKeyReleased(Keys key) => _currentKeyboardState.IsKeyUp(key) && _previousKeyboardState.IsKeyDown(key);

    public bool IsLeftMouseButtonClicked() =>
        _currentMouseState.LeftButton == ButtonState.Released &&
        _previousMouseState.LeftButton == ButtonState.Pressed;

    public bool IsRightMouseButtonClicked() => _currentMouseState.RightButton == ButtonState.Released && _previousMouseState.RightButton == ButtonState.Pressed;
    public bool IsMiddleMouseButtonClicked() => _currentMouseState.MiddleButton == ButtonState.Released && _previousMouseState.MiddleButton == ButtonState.Pressed;
}
