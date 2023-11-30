﻿using Core.Patterns.Behaviours.EventBus;
using Core.Patterns.Behaviours.EventBus.Events;
using Core.Patterns.Behaviours.FiniteStateMachines;
using Managers.StateManagement.Program.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Text;

namespace Managers.StateManagement.Program;

public class GameManager : StateMachine<GameState, GameManager>
{
    private EventBinding<ChangeGameStateEvent> _changeGameStateEventBinding;
    private EventBinding<RequestExitGameEvent> _requestExitGameEventBinding;

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

        _changeGameStateEventBinding = new EventBinding<ChangeGameStateEvent>(e => ChangeState(GameStateFactory.BuildByName(e.SceneName)));
        EventBus<ChangeGameStateEvent>.Register(_changeGameStateEventBinding);

        _requestExitGameEventBinding = new EventBinding<RequestExitGameEvent>(OnExitGame);
        EventBus<RequestExitGameEvent>.Register(_requestExitGameEventBinding);
    }

    public void Update(GameTime gameTime)
    {
        try
        {
            CurrentState?.CoreUpdate(gameTime);
            CurrentState?.Update(gameTime);
        }
        catch (Exception e)
        {
            StringBuilder sb = new();
            sb.Append($"=== Exception during Update(): {e.Message}");
            if (e.InnerException != null)
                sb.Append($", {e.InnerException}");
            Debug.WriteLine(sb.ToString());

            OnExitGame();
        }
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        try
        {
            CurrentState?.Draw(spriteBatch, gameTime);
        }
        catch (Exception e)
        {
            StringBuilder sb = new();
            sb.Append($"=== Exception during Draw(): {e.Message}");
            if (e.InnerException != null)
                sb.Append($", {e.InnerException}");
            Debug.WriteLine(sb.ToString());

            OnExitGame();
        }
    }

    public void OnExitGame()
    {
        ExitRequested?.Invoke();
    }
}