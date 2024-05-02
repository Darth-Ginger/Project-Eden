using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataRegistry<T> : SerializableScriptableObject where T: SerializableScriptableObject
{

    [SerializedDictionary("Guid", "Object")]
    private SerializedDictionary<Guid, T> guidToObjectMap = new();

    /// <summary>
    /// Registers an object in the registry if it has a valid Guid and is not already registered.
    /// </summary>
    /// <param name="obj">The object to register.</param>
    /// <returns>True if the object was successfully registered, false otherwise.</returns>
    public bool Register(T obj)
    {
        if (obj.Guid == null 
            || !guidToObjectMap.ContainsKey(obj.Guid))
        {
            return false;    
        }
        guidToObjectMap.Add(obj.Guid, obj);
        return true;
    }
    /// <summary>
    /// Unregisters an object from the registry based on its Guid.
    /// </summary>
    /// <param name="obj">The object to unregister.</param>
    /// <returns>True if the object was successfully unregistered, false otherwise.</returns>
    public bool Unregister(T obj)
    {
        if (obj.Guid == null) return false;
        return Unregister(obj.Guid);
    }
    /// <summary>
    /// Unregisters an object from the registry based on its Guid.
    /// </summary>
    /// <param name="guid">The Guid of the object to unregister.</param>
    /// <returns>True if the object was successfully unregistered, false otherwise.</returns>
    public bool Unregister(Guid guid)
    {
        if (!guidToObjectMap.ContainsKey(guid)) return false;
        guidToObjectMap.Remove(guid);
        return true;
    }
    /// <summary>
    /// Retrieves an object from the guidToObjectMap dictionary based on the provided guid.
    /// </summary>
    /// <param name="guid">The guid associated with the object.</param>
    /// <returns>The object if found, otherwise null.</returns>
    public T GetObject(Guid guid)
    {
        if (guidToObjectMap.TryGetValue(guid, out T obj))
        {
            if (guidToObjectMap.TryGetValue(guid, out T so)){
                return so;
            }
        }
        return null;
    }
    /// <summary>
    /// Retrieves an object from the registry based on its name.
    /// </summary>
    /// <param name="name">The name of the object to retrieve.</param>
    /// <returns>The object with the specified name, or null if no object with that name is found.</returns>
    public T GetObject(string name)
    {
        foreach (var obj in guidToObjectMap.Values)
        {
            if (obj.name == name) {
                return obj;
            }
        }
        return null;
    }

    public T GetRandom() => guidToObjectMap.Values.Take(1).ElementAt(Random.Range(0, guidToObjectMap.Count));
    public T[] GetRandom(int count = 1) => guidToObjectMap.Values.Take(count).ToArray();
    public T[] GetAll() => guidToObjectMap.Values.ToArray();
    public T GetFirst() => guidToObjectMap.Values.Take(1).ElementAt(0);
    public T GetLast() => guidToObjectMap.Values.Take(1).ElementAt(guidToObjectMap.Count - 1);
}
