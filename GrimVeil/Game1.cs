using Managers.InputManagement;
using Managers.SceneManagement;
using Managers.StateManagement.Program;
using Managers.StateManagement.Program.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrimVeil;

public class Game1 : Game
{
    private SpriteBatch? _spriteBatch;
    private readonly GameManager _gameManager;

    private readonly Color CLEARCOLOR = new(new Vector3(0, 0, 0.2f));

    public Game1()
    {
        GraphicsDeviceManager graphics = new(this);
        graphics.SynchronizeWithVerticalRetrace = false;

        IsFixedTimeStep = false;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        Window.Title = "Grim Veil";

        _gameManager = new GameManager(graphics, Content, Window);
        _gameManager.ExitRequested += OnExit;
    }

    protected override void Initialize()
    {
        SceneBuilder.Initialize(Content);
        GameStateFactory.Initialize(_gameManager);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        SceneManager.AddScene("splashScreen", SceneBuilder.BuildSplashScreen());
       
        _gameManager.ChangeState(new SplashScreenState(_gameManager));
    }

    protected override void Update(GameTime gameTime)
    {
        InputManager.Update(gameTime);
        _gameManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(CLEARCOLOR);

        if (_spriteBatch != null)
        {
            _spriteBatch.Begin();
            _gameManager.Draw(_spriteBatch, gameTime);
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