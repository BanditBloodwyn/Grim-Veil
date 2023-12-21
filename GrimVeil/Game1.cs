using Globals.Enums;
using Managers.InputManagement;
using Managers.SceneManagement;
using Managers.StateManagement;
using Managers.StateManagement.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrimVeil;

public class Game1 : Game
{
    private SpriteBatch? _spriteBatch;
    private readonly GameManager _gameManager;
    private readonly SceneManager _sceneManager;
    private readonly InputManager _inputManager;

    private readonly Color CLEARCOLOR = new(new Vector3(0, 0, 0.2f));

    public Game1()
    {
        GraphicsDeviceManager graphics = new(this);
        graphics.SynchronizeWithVerticalRetrace = false;

        IsFixedTimeStep = false;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        Window.Title = "Grim Veil";

        _gameManager = new GameManager(graphics, Window);
        _gameManager.ExitRequested += OnExit;

        _sceneManager = new SceneManager();
        _sceneManager.RequestActiveStateName += _gameManager.GetActiveStateName;
        
        _inputManager = new InputManager();
    }

    protected override void Initialize()
    {
        SceneBuilder.Initialize(Content);
        GameStateFactory.Initialize(_gameManager);

        base.Initialize();

        _gameManager.ChangeState(GameStateFactory.BuildByName(StateNames.SplashScreen));
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

        if (_spriteBatch != null)
        {
            _spriteBatch.Begin();
            _sceneManager.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();
        }

        base.Draw(gameTime);
    }

    public void OnExit()
    {
        Exit();
        Environment.Exit(0);
    }
}