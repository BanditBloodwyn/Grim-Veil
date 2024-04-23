using GV.EventBus;
using GV.FiniteStateMachines;
using GV.GameEvents;
using GV.StateManagement.States;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Text;
using GV.CoreUtilities;
using System.Reflection;

namespace GV.StateManagement;

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

        EventBinding<ChangeGameStateEvent> changeGameStateEventBinding = new(@event => ChangeGameState(@event.StateName));
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

    public void ChangeGameState(string stateName)
    {
        Type type = GetStateTypeFromString(stateName);
        GameState newState = new GameStateFactory().InvokeGenericMethod<GameState>("BuildByType", type);
        ChangeState(newState);
    }

    private static Type GetStateTypeFromString(string stateName)
    {
        Assembly? assembly = Assembly.GetAssembly(typeof(GameState));
        return assembly?.GetType($"GV.StateManagement.States.{stateName}")
               ?? throw new ArgumentException($"Failed to get type for state name {stateName}");
    }

    public void OnExitGame()
    {
        ExitRequested?.Invoke();
    }
}