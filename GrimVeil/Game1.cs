using Framework.Debugging;
using Framework.InputManagement;
using GameObjects.Utilities;
using Globals;
using Globals.Enums;
using Managers.SceneManagement;
using Managers.StateManagement;
using Managers.StateManagement.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Pools;

namespace GrimVeil;

public class Game1 : Game
{
    private readonly GameManager _gameManager;
    private readonly SceneManager _sceneManager;
    private readonly InputManager _inputManager;
    private readonly GraphicsDeviceManager _graphics;

    private readonly Color CLEARCOLOR = new(new Vector3(0, 0, 0.2f));

    private SpriteBatch? _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.SynchronizeWithVerticalRetrace = false;

        IsFixedTimeStep = false;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        Window.Title = "Grim Veil";

        _gameManager = new GameManager(_graphics, Window);
        _gameManager.ExitRequested += OnExit;

        _sceneManager = new SceneManager();
        _inputManager = new InputManager();

        DebugConsole.RequestActiveStateName += _gameManager.GetActiveStateName;
    }

    protected override void Initialize()
    {
        InitializePools();
        GameStateFactory.Initialize(_gameManager);

        base.Initialize();

        _gameManager.ChangeState(GameStateFactory.BuildByName(StateNames.SplashScreen));
    }

    private void InitializePools()
    {
        ResourcePool.Initialize(Content);
        ContentPool.Initialize(Content);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        _inputManager.Update(gameTime);
        _gameManager.Update(gameTime);
        _sceneManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(CLEARCOLOR);

        DrawWithCamera(gameTime);
        DrawWithoutCamera(gameTime);

        base.Draw(gameTime);
    }

    private void DrawWithoutCamera(GameTime gameTime)
    {
        if (_spriteBatch == null)
            return;

        _spriteBatch.Begin();

        if (Settings.SHOWDEBUGINFO)
            DebugConsole.Draw(_spriteBatch, gameTime);

        _spriteBatch.End();
    }

    private void DrawWithCamera(GameTime gameTime)
    {
        if (_spriteBatch == null)
            return;

        _spriteBatch.Begin(
            SpriteSortMode.Deferred,
            BlendState.AlphaBlend,
            null,
            null,
            null,
            null,
            Camera.Instance.GetTransformation(_graphics.GraphicsDevice));
        _sceneManager.Draw(_spriteBatch, gameTime);
        _spriteBatch.End();
    }

    public void OnExit()
    {
        Exit();
        Environment.Exit(0);
    }
}