using Framework.Extentions;
using Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Framework.Debugging;

public static class DebugConsole
{
    private static readonly List<WeakReference> _instances = new();

    public static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        if (!Settings.SHOWDEBUGINFO)
            return;
        
        if (_instances.Count == 0)
            return;

        for (int i = 0; i < _instances.Count; i++)
        {
            if (_instances[i].Target is IDebugInfoProvider debugInfoProvider)
                spriteBatch.WriteDefaultString(debugInfoProvider.GetDebugInfo(), 3, i * 20);
        }
    }

    public static void AddObject(IDebugInfoProvider instance)
    {
        _instances.Add(new WeakReference(instance));
        CleanUp();
    }

    private static void CleanUp()
    {
        _instances.RemoveAll(static reference => !reference.IsAlive);
    }
}