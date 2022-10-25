using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceManager
{

    public void Instantiate<T>(string path) where T : Object
    { 
        Manager.Interface.MapperCoroutine(LoadAsync<T>(path));
    }

    IEnumerator LoadAsync<T>(string path) where T : Object
    {
        // TODO 제넥릭 타입은 T 로받고 Load와  Instantiate 분리.
        ResourceRequest request = Resources.LoadAsync<T>($"Frefabs/{path}");
        
        while (!request.isDone)
        {
            yield return null;
        }
        
        if (request.asset == null)
        {
            Debug.Log($"gameObject not Find [path name is {path}]");
            yield break;
        }
        
        yield return request.asset as T;
        

    }
}
