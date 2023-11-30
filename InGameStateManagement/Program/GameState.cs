using Core.Patterns.Behaviours.FiniteStateMachines;
using Managers.SceneManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pools;
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

        if (!_loadedScene?.IsEmpty ?? false)
            return;

        spriteBatch.DrawString(ContentPool.Fonts["Default"], "State:", new Vector2(3, 3), Color.White);
        spriteBatch.DrawString(ContentPool.Fonts["Default"], $"{GetType()}", new Vector2(100, 3), Color.White);

        spriteBatch.DrawString(ContentPool.Fonts["Default"], "Gametime:", new Vector2(3, 23), Color.White);
        spriteBatch.DrawString(ContentPool.Fonts["Default"], $"{gameTime.TotalGameTime.TotalSeconds:N1} sec, {gameTime.ElapsedGameTime.Milliseconds} ms", new Vector2(100, 23), Color.White);
    }
}