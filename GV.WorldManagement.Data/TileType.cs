using GV.Repositories.Core;

namespace GV.WorldManagement.Data;

public class TileType : ILoadable
{
    public string Name { get; set; }
    public string? TextureName { get; set; }
    public bool IsWalkable { get; set; }
    public bool IsAir { get; set; }

    public override string ToString()
    {
        return Name;
    }
}