using System.Diagnostics;
using System.Reflection;

namespace GV.CoreUtilities
{
    public static class TypeLoader
    {
        public static Type[] LoadTypesByParentType<T>()
        {
            Assembly? assembly = Assembly.GetAssembly(typeof(T));

            if (assembly == null)
            {
                Debug.WriteLine("No assembly with class 'TileType' was found!");
                return Array.Empty<Type>();
            }

            return assembly
                .GetTypes()
                .Where(static t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(T)))
                .ToArray();
        }

        public static T[] CreateTypeInstancesByParentType<T>()
        {
            Type[] tileTypes = LoadTypesByParentType<T>();

            T[] instances = CreateTileTypeInstances<T>(tileTypes).ToArray();
            return instances;
        }

        private static IEnumerable<T> CreateTileTypeInstances<T>(Type[] tileTypes)
        {
            foreach (Type type in tileTypes)
            {
                object? instance = Activator.CreateInstance(type);

                if (instance is T tileType)
                    yield return tileType;
            }
        }
    }
}
