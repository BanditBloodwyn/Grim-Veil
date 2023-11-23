using IDrawable = Core.Game.IDrawable;
using IUpdatable = Core.Game.IUpdatable;

namespace Pools;

public class ObjectPool
{
    public Dictionary<object, IUpdatable> Updateables = new();
    public Dictionary<object, IDrawable> Drawables = new();

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
}