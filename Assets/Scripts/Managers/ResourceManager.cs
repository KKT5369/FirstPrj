using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceManager
{
    public void Instantiate<T>(string path) where  T : Object
    {
        Manager.Instance.CoroutineHelper(LoadAsync<T>(path));
    }

    IEnumerator LoadAsync<T>(string path) where T : Object
    {
        ResourceRequest request = Resources.LoadAsync<T>($"Prefabs/{path}");
        
        while (!request.isDone)
        {
            yield return null;
        }
        
        if (request.asset == null)
        {
            Debug.Log($"gameObject not Find [path name is {path}]");
            yield break;
        }

        if (typeof(T) == typeof(GameObject))
        {
            yield return Object.Instantiate(request.asset);
        }

    }
}
