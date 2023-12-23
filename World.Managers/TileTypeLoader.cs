using GameObjects.World.Tiles.TileTypes;
using System.Diagnostics;
using System.Reflection;

namespace World.Managers;

public class TileTypeLoader
{
    public static TileType[] LoadAllTileTypes()
    {
        Assembly? assembly = Assembly.GetAssembly(typeof(TileType));

        if (assembly == null)
        {
            Debug.WriteLine("No assembly with class 'TileType' was found!");
            return Array.Empty<TileType>();
        }

        Type[] tileTypes = assembly
            .GetTypes()
            .Where(static t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(TileType)))
            .ToArray();


        TileType[] instances = CreateTileTypeInstances(tileTypes).ToArray();
        return instances;
    }

    private static IEnumerable<TileType> CreateTileTypeInstances(Type[] tileTypes)
    {
        foreach (Type type in tileTypes)
        {
            object? instance = Activator.CreateInstance(type);

            if (instance is TileType tileType)
                yield return tileType;
        }
    }
}