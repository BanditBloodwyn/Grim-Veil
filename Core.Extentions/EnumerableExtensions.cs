namespace GV.TypeExtentions;

public static class EnumerableExtensions
{
    private static readonly Random random = new();

    public static T PickRandom<T>(this IEnumerable<T> source)
    {
        if (source == null) 
            throw new ArgumentNullException(nameof(source));
        
        if (!source.Any()) 
            throw new InvalidOperationException("Cannot pick an item from an empty set.");

        int count = source.Count();
        int index = random.Next(count);
        
        return source.ElementAt(index);
    }
}