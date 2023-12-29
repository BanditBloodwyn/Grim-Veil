namespace Core.Patterns.Creators.Singletons;

public abstract class Singleton<T>
    where T : class
{
    private static readonly Lazy<T> _instance = new(CreateInstanceOfT);

    public static T Instance => _instance.Value;

    private static T CreateInstanceOfT()
    {
        return Activator.CreateInstance(typeof(T), true) as T 
               ?? throw new ArgumentNullException($"Cannot create instance of type {typeof(T).Name}");
    }
}