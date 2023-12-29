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

    public event Func<string>? RequestActiveStateName;

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
    
    public void DrawWithoutCamera(SpriteBatch spriteBatch, GameTime gameTime)
    {
        _activeScene?.DrawWithoutCamera(spriteBatch, gameTime);
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
            newScene!.RequestActiveStateName += OnRequestActiveStateName;
            AddScene(@event.SceneName, newScene);
            _activeScene = newScene;
            return;
        }

        Debug.WriteLine("Cannot get scene!");
    }

    private string OnRequestActiveStateName()
    {
        return RequestActiveStateName?.Invoke() ?? string.Empty;
    }

    private void AddScene(SceneNames stateName, Scene scene)
    {
        _cachedScenes.TryAdd(stateName, scene);
    }
}