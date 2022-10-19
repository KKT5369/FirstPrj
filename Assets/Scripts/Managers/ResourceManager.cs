using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ResourceManager 
{
    private T LoadAsync<T>(string path) where T : Object
    {
        ResourceRequest request = Resources.LoadAsync<T>(path);
        T gb = request.asset as T;
        return gb;
    }

    // public async Task<T> InstantiateAsync<T>(string paht) where T : Object
    // {
    //     T go = await Task.Run(() =>
    //     {
    //         return Instantiate<T>(paht);
    //     });
    //     return go;
    // }

    public  T Instantiate<T>(string path) where T : Object
    {
        T go = LoadAsync<T>($"Frefabs/{path}");
        return Object.Instantiate(go);
    }

    
}
