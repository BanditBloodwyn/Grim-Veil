using GV.EventBus;
using GV.GameEvents;
using GV.Globals.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace GV.SceneManagement;

public class SceneManager
{
    private readonly Dictionary<SceneNames, Scene> _cachedScenes = new();

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

        if (SceneBuilder.TryBuildByName(@event.SceneName, out Scene? newScene))
        {
            AddScene(@event.SceneName, newScene!);

            if (_activeScene != null)
                _activeScene.IsDebugActive = false;

            newScene!.IsDebugActive = true;
            _activeScene = newScene;
            return;
        }

        Debug.WriteLine("Cannot get scene!");
    }

    private void AddScene(SceneNames stateName, Scene scene)
    {
        _cachedScenes.TryAdd(stateName, scene);
    }
}