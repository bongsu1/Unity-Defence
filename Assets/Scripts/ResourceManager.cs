using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    Dictionary<string, Object> resources = new Dictionary<string, Object>();
    public T Load<T>(string path) where T : Object
    {
        string key = $"{typeof(T)}.{path}";

        if (resources.ContainsKey(key))
            return resources[key] as T;

        T resource = Resources.Load<T>(path);
        resources.Add(key, resource);
        return resource;
    }
}
