using Core.Patterns.Behaviours.FiniteStateMachines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrimVeil.GameManagement;

public class GameManager : StateMachine<GameState, GameManager>
{
    public event Action? ExitRequested;

    public ContentManager Content { get; }
    public GraphicsDeviceManager Graphics { get; }
    public GameWindow Window { get; }

    public GameManager(
        GraphicsDeviceManager graphics,
        ContentManager contentManager,
        GameWindow gameWindow)
    {
        Content = contentManager;
        Graphics = graphics;
        Window = gameWindow;
    }

    public void Update(GameTime gameTime)
    {
        CurrentState?.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        CurrentState?.Draw(spriteBatch, gameTime);
    }

    public void OnExitGame()
    {
        ExitRequested?.Invoke();
    }
}