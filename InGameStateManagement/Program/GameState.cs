using Core.Extentions;
using Core.Patterns.Behaviours.FiniteStateMachines;
using Managers.SceneManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Managers.StateManagement.Program;

public abstract class GameState : State<GameState, GameManager>
{
    protected Scene? _loadedScene;

    protected abstract string AssociatedSceneName { get; }

    protected GameState(GameManager stateMachine)
        : base(stateMachine)
    { }

    public override void OnBegin()
    {
        LoadScene();
        OnInitialize();
    }

    private void LoadScene()
    {
        if (!SceneManager.TryGetSceneByName(AssociatedSceneName, out Scene scene))
            Debug.WriteLine("Scene not found!");

        _loadedScene = scene;
    }

    protected virtual void OnInitialize() { }

    public void CoreUpdate(GameTime gameTime)
    {
        _loadedScene?.Update(gameTime);
    }

    public virtual void Update(GameTime gameTime) { }

    public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        _loadedScene?.Draw(spriteBatch);

        WriteDebugInfo(spriteBatch, gameTime);
    }

    private void WriteDebugInfo(SpriteBatch spriteBatch, GameTime gameTime)
    {
        spriteBatch.WriteDefaultString("Gametime:", 3, 23);
        spriteBatch.WriteDefaultString($"{gameTime.TotalGameTime.TotalSeconds:N1} sec, {gameTime.ElapsedGameTime.Milliseconds} ms", 100, 23);

        spriteBatch.WriteDefaultString("State:", 3, 3);
        spriteBatch.WriteDefaultString($"{GetType().Name}", 100, 3);

        if (_loadedScene != null)
            spriteBatch.WriteDefaultString(_loadedScene.GetDebugInfo(), 3, 63);
    }
}