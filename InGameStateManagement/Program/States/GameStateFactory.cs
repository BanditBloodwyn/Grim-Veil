namespace Managers.StateManagement.Program.States;

public class GameStateFactory
{
    private static GameManager _gameManager = null!;
    private static bool _initialized;

    public static void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        _initialized = true;
    }

    public static GameState BuildByName(string name)
    {
        return name switch
        {
            "splashScreenState" => SplashScreen(),
            "loadingScreenState" => LoadingScreen(),
            "mainMenuState" => MainMenu(),
            "inGameState" => InGame(),
            _ => SplashScreen()
        };
    }

    public static GameState SplashScreen()
    {
        if (!_initialized)
            throw new Exception("GameStateFactory not initialized!");

        return new SplashScreenState(_gameManager);
    }
    public static GameState LoadingScreen()
    {
        if (!_initialized)
            throw new Exception("GameStateFactory not initialized!");

        return new LoadingScreenState(_gameManager);
    }
    public static GameState MainMenu()
    {
        if (!_initialized)
            throw new Exception("GameStateFactory not initialized!");

        return new MainMenuState(_gameManager);
    }
    public static GameState InGame()
    {
        if (!_initialized)
            throw new Exception("GameStateFactory not initialized!");

        return new InGameState(_gameManager);
    }
}