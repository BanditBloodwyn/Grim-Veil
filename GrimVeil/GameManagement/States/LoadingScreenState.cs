using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using System;
using UI.Core;
using UI.Core.Factories;

namespace GrimVeil.GameManagement.States;

public class LoadingScreenState : GameState
{
    private readonly int _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    private readonly int _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
    private TimeSpan? _startingTime;
    
    public override string StateLogString => "Loading Screen";

    public LoadingScreenState(GameManager stateMachine, ContentManager content)
        : base(stateMachine, content)
    { }

    protected override void OnLoadContent()
    {
        ContentPool.LoadLoadingScreenContent(Content);

        ObjectPool.AddObject(
            "loadingScreen_Background1",
            new Image(
                ContentPool.Textures["loadingScreen_Background1"],
                new Rectangle(0, 0, _screenWidth, _screenHeight)));

        ObjectPool.AddObject(
            "loadingScreen_Label",
            LabelFactory.CreateLabel(
                "Loading...", 
                ContentPool.Fonts["Victorian"],
                _screenWidth / 2, 
                _screenHeight - 50, 
                true));
    }

    protected override void OnInitialize()
    {
        stateMachine.Window.Position = new Point(0, 0);
        stateMachine.Graphics.PreferredBackBufferWidth = _screenWidth;
        stateMachine.Graphics.PreferredBackBufferHeight = _screenHeight;
        //stateMachine.Graphics.IsFullScreen = true;
        stateMachine.Graphics.ApplyChanges();
    }

    public override void Update(GameTime gameTime)
    {
        _startingTime ??= gameTime.TotalGameTime;

        while (gameTime.TotalGameTime.TotalSeconds - _startingTime.Value.TotalSeconds < 1)
            return;

        ContentPool.LoadContent(Content);

        ChangeState(new MainMenuState(stateMachine, Content));
    }
}