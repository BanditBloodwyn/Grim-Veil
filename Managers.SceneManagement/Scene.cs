using Core.Extentions;
using Core.Patterns.Behaviours.EventBus;
using Framework.Extentions;
using Framework.Game;
using Framework.GameEvents;
using GameObjects.Utilities;
using Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Text;
using Framework.InputManagement;
using IDrawable = Framework.Game.IDrawable;

namespace Managers.SceneManagement;

public class Scene
{
    public Dictionary<object, IUpdatable> Updateables = new();
    public Dictionary<object, IDrawable> Drawables = new();
    public Dictionary<object, IDrawableIgnoreCamera> DrawablesWithoutCamera = new();

    public event Func<string>? RequestActiveStateName;

    public bool NoUpdatables => Updateables.Count == 0;
    public bool NoDrawables => Drawables.Count == 0;
    public bool IsEmpty => NoUpdatables && NoDrawables;

    public string? Name { get; set; }

    public void AddObject(object key, object @object)
    {
        if (@object is IUpdatable updateable)
            Updateables.Add(key, updateable);
        if (@object is IDrawable drawable)
            Drawables.Add(key, drawable);
        if (@object is IDrawableIgnoreCamera drawableWithoutCamera)
            DrawablesWithoutCamera.Add(key, drawableWithoutCamera);
    }

    public void RemoveObject(object key)
    {
        if (Updateables.ContainsKey(key))
            Updateables.Remove(key);
        if (Drawables.ContainsKey(key))
            Drawables.Remove(key);
        if (DrawablesWithoutCamera.ContainsKey(key))
            DrawablesWithoutCamera.Remove(key);
    }

    public void Update(GameTime gameTime)
    {
        foreach (KeyValuePair<object, IUpdatable> pair in Updateables)
            pair.Value.Update(gameTime);

        if (!IsEmpty)
            return;

        if (InputManager.IsKeyPressed(Keys.Escape))
            EventBus<RequestExitGameEvent>.Raise(new RequestExitGameEvent());

        if (InputManager.IsKeyPressed(Keys.Space))
            Debug.WriteLine("Space");
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        foreach (KeyValuePair<object, IDrawable> pair in Drawables)
            pair.Value.Draw(spriteBatch);
    }

    public void DrawWithoutCamera(SpriteBatch spriteBatch, GameTime gameTime)
    {
        if (Settings.SHOWDEBUGINFO)
            WriteDebugInfo(spriteBatch, gameTime);
    }

    private void WriteDebugInfo(SpriteBatch spriteBatch, GameTime gameTime)
    {
        spriteBatch.WriteDefaultString("Gametime:", 3, 23);
        spriteBatch.WriteDefaultString($"{gameTime.TotalGameTime.TotalSeconds:N1} sec, {gameTime.ElapsedGameTime.TotalMilliseconds} ms", 100, 23);

        spriteBatch.WriteDefaultString("Active state:", 3, 3);
        spriteBatch.WriteDefaultString($"{RequestActiveStateName?.Invoke()}", 100, 3);


        spriteBatch.WriteDefaultString(Camera.Instance.GetDebugInfo(), 3, 63);
        spriteBatch.WriteDefaultString(GetDebugInfo(), 3, 203);
    }

    public string GetDebugInfo()
    {
        StringBuilder sb = new();

        sb.AppendLine("Scene Info:");

        sb.AppendSpaceTab().Append("Name:");
        if (Name != null)
            sb.AppendSpaceTab().Append(Name);

        sb.AppendLine();
        sb.AppendSpaceTab().Append("Updatables:").AppendSpaceTab().Append(Updateables.Count);
        sb.AppendLine();
        sb.AppendSpaceTab().Append("Drawables: ").AppendSpaceTab().Append(Drawables.Count);

        return sb.ToString();
    }
}
