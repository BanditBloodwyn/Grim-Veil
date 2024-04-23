namespace GV.WorldManagement.Data;

public class TileType
{
    public string Name { get; set; }
    public string? TextureName { get; set; }
    public bool IsWalkable { get; set; }
    public bool IsAir { get; set; }
}