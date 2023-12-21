using System.Diagnostics;
using System.Text;
using Core.Patterns.Behaviours.EventBus;
using Core.Patterns.Behaviours.FiniteStateMachines;
using Framework.GameEvents;
using Managers.StateManagement.States;
using Microsoft.Xna.Framework;

namespace Managers.StateManagement;

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

        EventBinding<ChangeGameStateEvent> changeGameStateEventBinding = new(
            @event => ChangeState(GameStateFactory.BuildByName(@event.StateName)));
        EventBus<ChangeGameStateEvent>.Register(changeGameStateEventBinding);

        EventBinding<RequestExitGameEvent> requestExitGameEventBinding = new(OnExitGame);
        EventBus<RequestExitGameEvent>.Register(requestExitGameEventBinding);
    }

    public void Update(GameTime gameTime)
    {
        try
        {
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

    public string GetActiveStateName()
    {
        return CurrentState?.GetType().Name ?? string.Empty;
    }

    public void OnExitGame()
    {
        ExitRequested?.Invoke();
    }
}