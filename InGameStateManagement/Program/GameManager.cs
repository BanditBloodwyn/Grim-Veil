using Core.Patterns.Behaviours.EventBus;
using Core.Patterns.Behaviours.FiniteStateMachines;
using Managers.StateManagement.Program.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Text;
using Framework.GameEvents;

namespace Managers.StateManagement.Program;

public class GameManager : StateMachine<GameState, GameManager>
{
    public event Action? ExitRequested;

    public GraphicsDeviceManager Graphics { get; }
    public GameWindow Window { get; }

    public GameManager(
        GraphicsDeviceManager graphics,
        GameWindow gameWindow)
    {
        Graphics = graphics;
        Window = gameWindow;

        EventBinding<ChangeGameStateEvent> changeGameStateEventBinding = new(@event =>
            ChangeState(GameStateFactory.BuildByName(@event.StateName)));
        EventBus<ChangeGameStateEvent>.Register(changeGameStateEventBinding);

        EventBinding<RequestExitGameEvent> requestExitGameEventBinding = new(OnExitGame);
        EventBus<RequestExitGameEvent>.Register(requestExitGameEventBinding);
    }

    public void Update(GameTime gameTime)
    {
        try
        {
            CurrentState?.SceneUpdate(gameTime);
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