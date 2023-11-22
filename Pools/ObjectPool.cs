using Microsoft.Xna.Framework;
using IDrawable = Core.Game.IDrawable;

namespace Pools;

public class ObjectPool
{
    public Dictionary<object, IUpdateable> Updateables = new();
    public Dictionary<object, IDrawable> Drawables = new();

    public void AddObject(object key, object @object)
    {
        if (@object is IUpdateable updateable)
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
}