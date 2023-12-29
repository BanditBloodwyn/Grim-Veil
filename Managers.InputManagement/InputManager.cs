using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Framework.InputManagement;
public class InputManager
{
    private static KeyboardState _currentKeyboardState;
    private static KeyboardState _previousKeyboardState;
    private static MouseState _currentMouseState;
    private static MouseState _previousMouseState;

    public void Update(GameTime gameTime)
    {
        _previousKeyboardState = _currentKeyboardState;
        _currentKeyboardState = Keyboard.GetState();
        _previousMouseState = _currentMouseState;
        _currentMouseState = Mouse.GetState();
    }

    public static MouseState GetCurrentMouseState() => _currentMouseState;

    public static bool IsKeyPressed(Keys key) => _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
    public static bool IsKeyHeld(Keys key) => _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyDown(key);
    public static bool IsKeyReleased(Keys key) => _currentKeyboardState.IsKeyUp(key) && _previousKeyboardState.IsKeyDown(key);
   
    public static bool IsControlHeld() => IsKeyHeld(Keys.LeftControl) || IsKeyHeld(Keys.RightControl);
    
    public static bool IsLeftMouseButtonClicked() => _currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed;
    public static bool IsRightMouseButtonClicked() => _currentMouseState.RightButton == ButtonState.Released && _previousMouseState.RightButton == ButtonState.Pressed;

    public static bool IsMiddleMouseButtonClicked() => _currentMouseState.MiddleButton == ButtonState.Released && _previousMouseState.MiddleButton == ButtonState.Pressed;
    public static bool IsMiddleMouseButtonHeld() => _currentMouseState.MiddleButton == ButtonState.Pressed && _previousMouseState.MiddleButton == ButtonState.Pressed;

    public static Point MouseDelta() => _currentMouseState.Position - _previousMouseState.Position;

    public static float MouseWheelDelta() => _currentMouseState.ScrollWheelValue - _previousMouseState.ScrollWheelValue;
}
