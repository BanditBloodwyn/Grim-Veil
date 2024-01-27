namespace GameObjects.World.Tiles.TileTypes;

public class AirOldTileType : oldTileType
{
    public override string Name => "Air";
    public override bool IsWalkable => false;
    public override bool IsAir => true;
}