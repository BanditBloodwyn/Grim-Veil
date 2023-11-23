using GrimVeil.GameManagement;
using GrimVeil.GameManagement.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using System;

namespace GrimVeil
{
    public class Game1 : Game
    {
        private SpriteBatch? _spriteBatch;
        private readonly GameManager _gameManager;

        public Game1()
        {
            GraphicsDeviceManager graphics = new(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.Title = "Grim Veil";

            _gameManager = new GameManager(graphics, Content, Window);
            _gameManager.ExitRequested += OnExit;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ContentPool.LoadSplashScreenContent(Content);

            _gameManager.ChangeState(new SplashScreenState(_gameManager));

            ContentPool.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            _gameManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);

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
}