using Core.Patterns.Behaviours.EventBus;
using Framework.GameEvents;
using Globals.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Managers.SceneManagement;

public class SceneManager
{
    private readonly Dictionary<SceneNames, Scene> _cachedScenes = new();

    private Scene? _activeScene;

    public SceneManager()
    {
        EventBinding<ChangeActiveSceneEvent> requestExitGameEventBinding = new(OnChangeScene);
        EventBus<ChangeActiveSceneEvent>.Register(requestExitGameEventBinding);
    }

    public void Update(GameTime gameTime)
    {
        _activeScene?.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        _activeScene?.Draw(spriteBatch, gameTime);
    }

    private void OnChangeScene(ChangeActiveSceneEvent @event)
    {
        if (!TryGetSceneByName(@event.SceneName, out _activeScene))
            Debug.WriteLine("Cannot get scene!");
    }

    public bool TryGetSceneByName(SceneNames stateName, out Scene? scene)
    {
        scene = null;

        if (_cachedScenes.TryGetValue(stateName, out Scene? loadedScene))
        {
            scene = loadedScene;
            return true;
        }

        if (SceneBuilder.TryBuildByName(stateName, out Scene? newScene))
        {
            AddScene(stateName, newScene!);
            scene = newScene!;
            return true;
        }

        return false;
    }

    private void AddScene(SceneNames stateName, Scene scene)
    {
        _cachedScenes.TryAdd(stateName, scene);
    }
}