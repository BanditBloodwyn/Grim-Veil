using GV.CoreUtilities;
using GV.EventBus;
using GV.GameEvents;
using GV.SceneManagement.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;

namespace GV.SceneManagement;

public class SceneManager
{
    private readonly Dictionary<string, Scene> _cachedScenes = [];

    private Scene? _activeScene;

    public SceneManager()
    {
        EventBinding<ChangeActiveSceneEvent> changeActiveSceneEventBinding = new(OnChangeActiveScene);
        EventBus<ChangeActiveSceneEvent>.Register(changeActiveSceneEventBinding);
    }

    public void Update(GameTime gameTime)
    {
        _activeScene?.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        _activeScene?.Draw(spriteBatch, gameTime);
    }

    private void OnChangeActiveScene(ChangeActiveSceneEvent @event)
    {
        if (_cachedScenes.TryGetValue(@event.SceneName, out Scene? loadedScene))
        {
            _activeScene = loadedScene;
            return;
        }

        Type type = GetSceneTypeFromString(@event.SceneName);
        Scene newScene = new SceneFactory().InvokeGenericMethod<Scene>("BuildByType", type);

        AddSceneToCache(@event.SceneName, newScene);

        if (_activeScene != null)
            _activeScene.IsDebugActive = false;

        newScene.IsDebugActive = true;
        _activeScene = newScene;
    }

    private static Type GetSceneTypeFromString(string sceneName)
    {
        Assembly? assembly = Assembly.GetAssembly(typeof(Scene));
        return assembly?.GetType($"GV.SceneManagement.Scenes.{sceneName}")
               ?? throw new ArgumentException($"Failed to get type for scene name {sceneName}");
    }

    private void AddSceneToCache(string stateName, Scene scene)
    {
        _cachedScenes.TryAdd(stateName, scene);
    }
}