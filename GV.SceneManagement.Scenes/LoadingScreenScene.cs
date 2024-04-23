using GV.Pools;
using GV.UIObjects;
using GV.UIObjects.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GV.SceneManagement.Scenes;

public class LoadingScreenScene : Scene
{
    private static readonly int _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    private static readonly int _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

    public override void LoadResources()
    {
        ResourcePool.LoadAsset<Texture2D>("loadingScreen_Background1", "Images/loadingScreen1");
    }

    public override void Build()
    {
        Name = "Loading Screen Scene";

        Image background = new(new Rectangle(0, 0, _screenWidth, _screenHeight));
        background.Texture = ResourcePool.GetAsset<Texture2D>("loadingScreen_Background1");
        AddObject(
            "loadingScreen_Background1",
            background);

        Label label = LabelFactory.CreateLabel(
            "Loading...",
            ResourcePool.GetAsset<SpriteFont>("default"),
            _screenWidth / 2,
            _screenHeight - 50,
            true);
        label.Scale = new Vector2(2);
        AddObject(
            "loadingScreen_Label",
            label);

    }
}