using Core.Patterns.Behaviours.FiniteStateMachines;
using Globals;
using Globals.Enums;
using Managers.SceneManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Framework.Extentions;

namespace Managers.StateManagement.Program;

public abstract class GameState : State<GameState, GameManager>
{
    protected Scene? _loadedScene;

    protected abstract StateNames StateName { get; }

    protected GameState(GameManager stateMachine)
        : base(stateMachine)
    { }

    public override void OnBegin()
    {
        LoadScene();
        Initialize();
    }

    private void LoadScene()
    {
        if (!SceneManager.TryGetSceneByName(StateName, out Scene scene))
            Debug.WriteLine("Cannot get scene!");

        _loadedScene = scene;
    }

    protected virtual void Initialize() { }

    public void SceneUpdate(GameTime gameTime)
    {
        _loadedScene?.Update(gameTime);
    }

    public virtual void Update(GameTime gameTime) { }

    public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        _loadedScene?.Draw(spriteBatch);

        if (Settings.SHOWDEBUGINFO)
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