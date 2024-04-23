namespace GV.StateManagement.States;

public class GameStateFactory
{
    private static GameManager _gameManager = null!;
    private static bool _initialized;

    public static void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        _initialized = true;
    }

    public static GameState BuildByType<T>() 
        where T : GameState
    {
        if(!_initialized)
            throw new Exception("GameStateFactory not initialized!");

        Type type = typeof(T);

        GameState? gameState = (GameState?)Activator.CreateInstance(type, _gameManager);

        if (gameState != null) 
            return gameState;

        throw new Exception($"Failed to create GameState of type {type}");
    }
}