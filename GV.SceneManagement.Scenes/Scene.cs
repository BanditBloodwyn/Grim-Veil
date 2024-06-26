﻿using GV.Debugging;
using GV.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using GV.TypeExtentions;
using IDrawable = GV.Game.IDrawable;

namespace GV.SceneManagement.Scenes;

public abstract class Scene : IDebugInfoProvider
{
    public Dictionary<object, IUpdatable> Updateables = new();
    public Dictionary<object, IDrawable> Drawables = new();
    public Dictionary<object, IDrawableIgnoreCamera> DrawablesWithoutCamera = new();

    public bool NoUpdatables => Updateables.Count == 0;
    public bool NoDrawables => Drawables.Count == 0;
    public bool IsEmpty => NoUpdatables && NoDrawables;

    public string? Name { get; set; }

    public bool IsDebugActive { get; set; }

    protected Scene()
    {
        DebugConsole.AddObject(this);
    }

    public abstract void LoadResources();
   
    public abstract void Build();

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
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        foreach (KeyValuePair<object, IDrawable> pair in Drawables)
            pair.Value.Draw(spriteBatch);
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
