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
            Assets.TryAdd($"{nameof(T)}_{assetName}", asset);
    }

    public static T GetAsset<T>(string assetName)
    {
        if (_contentManager == null)
            throw new Exception("ContentManager not initialized!");

        if (!Assets.TryGetValue($"{nameof(T)}_{assetName}", out object? asset))
            throw new KeyNotFoundException($"Asset with name {nameof(T)}_{assetName} not found!");

        return (T)asset;
    }
}