namespace Shared.Core;

public class CollectionWorker
{
    public static void Add<T>(ICollection<T> collection, T item) where T : class
    {
        if (item == null) return;
        bool hasItem = HasItemInCollection(collection, item);
        if (hasItem) return;
        
        collection.Add(item);
    }

    private static bool HasItemInCollection<T>(ICollection<T> collection, T item)
    {
        if (collection == null) return false;
        if (collection.Count == 0) return false;
        foreach (T it in collection)
        {
            if (it.Equals(item)) return true;
        }
        return false;
    }
}
