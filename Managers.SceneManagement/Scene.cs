using Core.Game;
using Core.Patterns.Behaviours.EventBus;
using Core.Patterns.Behaviours.EventBus.Events;
using Managers.InputManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using IDrawable = Core.Game.IDrawable;

namespace Managers.SceneManagement;

public class Scene
{
    public Dictionary<object, IUpdatable> Updateables = new();
    public Dictionary<object, IDrawable> Drawables = new();

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
    }

    public void RemoveObject(object key)
    {
        if (Updateables.ContainsKey(key))
            Updateables.Remove(key);
        if (Drawables.ContainsKey(key))
            Drawables.Remove(key);
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

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (KeyValuePair<object, IDrawable> pair in Drawables)
            pair.Value.Draw(spriteBatch);
    }
}
