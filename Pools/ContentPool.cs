using Microsoft.Xna.Framework.Content;

namespace Pools;

public static class ContentPool
{
    private static ContentManager? _contentManager;

    public static void Initialize(ContentManager content)
    {
        _contentManager = content;
    }
}