using GV.Pools;
using GV.WorldManagement;
using GV.WorldManagement.Data;
using Microsoft.Xna.Framework.Graphics;

namespace GV.SceneManagement.Scenes;

public class InGameScene : Scene
{
    public override void LoadResources()
    {
        ResourcePool.LoadAsset<Texture2D>("tile_grass", "Environment/Tiles/grassTile");
        ResourcePool.LoadAsset<Texture2D>("tile_stone", "Environment/Tiles/stoneTile");
        ResourcePool.LoadAsset<Texture2D>("tile_dirt", "Environment/Tiles/dirtTile");
        ResourcePool.LoadAsset<Texture2D>("tile_water", "Environment/Tiles/waterTile");

        ResourcePool.LoadAllJsonData<TileType>();
    }

    public override void Build()
    {
        Name = "InGame Scene";

        EmbarkedMapBuilder embarkedMapBuilder = new(
            new TileTypeManager());

        AddObject("map",
            embarkedMapBuilder.Build(40, 20, -10, 10));
    }
}