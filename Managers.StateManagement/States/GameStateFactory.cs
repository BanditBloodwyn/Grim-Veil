using Globals.Enums;

namespace Managers.StateManagement.States;

public class GameStateFactory
{
    private static GameManager _gameManager = null!;
    private static bool _initialized;

    public static void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        _initialized = true;
    }

    public static GameState BuildByName(StateNames name)
    {
        return name switch
        {
            StateNames.SplashScreen => SplashScreen(),
            StateNames.StartupLoadingScreen => StartupLoadingScreen(),
            StateNames.MainMenu => MainMenu(),
            StateNames.IngameLoadingScreen => IngameLoadingScreen(),
            StateNames.Ingame_Normal => InGame_Normal(),
            _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
        };
    }

    private static GameState SplashScreen()
    {
        if (!_initialized)
            throw new Exception("GameStateFactory not initialized!");

        return new SplashScreenState(_gameManager);
    }

    private static GameState StartupLoadingScreen()
    {
        if (!_initialized)
            throw new Exception("GameStateFactory not initialized!");

        return new StartupLoadingScreenState(_gameManager);
    }

    private static GameState MainMenu()
    {
        if (!_initialized)
            throw new Exception("GameStateFactory not initialized!");

        return new MainMenuState(_gameManager);
    }

    private static GameState IngameLoadingScreen()
    {
        if (!_initialized)
            throw new Exception("GameStateFactory not initialized!");

        throw new NotImplementedException();
    }

    private static GameState InGame_Normal()
    {
        if (!_initialized)
            throw new Exception("GameStateFactory not initialized!");

        return new InGame_Normal_State(_gameManager);
    }
}