using GV.Globals;
using GV.Pools;
using GV.UIObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GV.SceneManagement.Scenes;

public class SplashScreenScene : Scene
{
    public override void LoadResources()
    {
        ResourcePool.LoadAsset<Texture2D>("splashscreen", "Images/splashscreen");
        ResourcePool.LoadAsset<Texture2D>("gameLogo", "Images/logo");
        ResourcePool.LoadAsset<SpriteFont>("default", "Fonts/Default");
    }

    public override void Build()
    {
        Name = "Splash Screen Scene";

        Image background = new(new Rectangle(0, 0, Settings.SPLASHSCREEN_WIDTH, Settings.SPLASHSCREEN_HEIGHT));
        background.Texture = ResourcePool.GetAsset<Texture2D>("splashscreen");
        AddObject(
            "background",
            background);

        Image logo = new(new Rectangle(Settings.SPLASHSCREEN_WIDTH / 4, 0, Settings.SPLASHSCREEN_WIDTH / 2, Settings.SPLASHSCREEN_WIDTH / 2));
        logo.Texture = ResourcePool.GetAsset<Texture2D>("gameLogo");
        AddObject(
            "logo",
            logo);

    }
}