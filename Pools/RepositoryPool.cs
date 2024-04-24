using GV.Repositories.JSON;

namespace GV.Pools;

public class RepositoryPool
{
    public static readonly JsonRepository Json = new();
}