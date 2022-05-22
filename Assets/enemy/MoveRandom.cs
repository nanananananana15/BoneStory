using System.Collections.Generic;
using System.Linq;

public static class RandomUtils
{
    public static T Random<T> (this IEnumerable<T> collection)
    {
        return collection.ElementAt(UnityEngine.Random.Range(0, collection.Count()));
    }
}