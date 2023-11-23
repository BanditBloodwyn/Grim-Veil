using IDrawable = Core.Game.IDrawable;
using IUpdatable = Core.Game.IUpdatable;

namespace Pools;

public class ObjectPool
{
    public Dictionary<object, IUpdatable> Updateables = new();
    public Dictionary<object, IDrawable> Drawables = new();

    public bool NoUpdatables => Updateables.Count == 0;
    public bool NoDrawables => Drawables.Count == 0;
    public bool IsEmpty => NoUpdatables && NoDrawables;

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