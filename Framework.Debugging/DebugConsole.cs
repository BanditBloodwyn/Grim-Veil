using Extentions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Debugging;

public static class DebugConsole
{
    private static readonly List<WeakReference> _instances = new();

    public static event Func<string>? RequestActiveStateName;

    public static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        if (_instances.Count == 0)
            return;

        IDebugInfoProvider[] debugInfoProviders = GetDebugConsoleEntries(_instances).ToArray();

        WriteTexts(spriteBatch, gameTime, debugInfoProviders);
    }

    private static void WriteTexts(SpriteBatch spriteBatch, GameTime gameTime, IDebugInfoProvider[] debugInfoProviders)
    {
        int posY = 3;

        spriteBatch.WriteDefaultString("Gametime:", 3, posY);
        spriteBatch.WriteDefaultString($"{gameTime.TotalGameTime.TotalSeconds:N1} sec, {gameTime.ElapsedGameTime.TotalMilliseconds} ms", 100, posY);
        posY += 20;

        spriteBatch.WriteDefaultString("Active state:", 3, posY);
        spriteBatch.WriteDefaultString($"{RequestActiveStateName?.Invoke()}", 100, posY);
        posY += 40;

        foreach (IDebugInfoProvider provider in debugInfoProviders)
        {
            posY += spriteBatch.WriteDefaultString(provider.GetDebugInfo(), 3, posY);
            posY += 20;
        }
    }

    private static IEnumerable<IDebugInfoProvider> GetDebugConsoleEntries(List<WeakReference> instances)
    {
        foreach (WeakReference reference in instances)
        {
            if (reference.Target is not IDebugInfoProvider debugInfoProvider)
                continue;

            if (!debugInfoProvider.IsDebugActive)
                continue;

            yield return debugInfoProvider;
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