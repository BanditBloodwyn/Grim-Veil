namespace GameObjects.World.Tiles.TileTypes;

public class AirTileType : TileType
{
    public override string Name => "Air";
    public override bool IsWalkable => false;
    public override bool IsAir => true;
}