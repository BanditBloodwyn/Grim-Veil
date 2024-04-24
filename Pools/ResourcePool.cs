using GV.Repositories.Core;
using Microsoft.Xna.Framework.Content;

namespace GV.Pools;

public static class ResourcePool
{
    private static ContentManager? _contentManager;

    public static Dictionary<object, object> Assets = [];

    public static void Initialize(ContentManager content)
    {
        _contentManager = content;
    }

    public static void LoadAsset<T>(string assetName, string path)
    {
        if (_contentManager == null)
            return;

        T asset = _contentManager.Load<T>(path);

        if (asset != null)
            Assets.TryAdd($"{typeof(T).Name}_{assetName}", asset);
    }

    public static T GetAsset<T>(string assetName)
    {
        if (!Assets.TryGetValue($"{typeof(T).Name}_{assetName}", out object? asset))
            throw new KeyNotFoundException($"Asset with name {typeof(T).Name}_{assetName} not found!");

        return (T)asset;
    }

    public static void LoadAllJsonData<T>() 
        where T : ILoadable
    {
        foreach (T data in RepositoryPool.Json.LoadAll<T>())
            Assets.TryAdd($"{typeof(T).Name}_{data}", data);
    }
}