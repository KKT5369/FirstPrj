using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceManager 
{

    public void Instantiate(string path)
    {
        Debug.Log("LoadAsync 호출");
        Manager.Interface.MapperCoroutine(LoadAsync(path));
    }

    IEnumerator LoadAsync(string path)
    {
        ResourceRequest request = Resources.LoadAsync<GameObject>($"Frefabs/{path}");

        if (request == null)
        {
            Debug.Log($"path is not find {path}");
            yield break;
        }
        
        while (!request.isDone)
        {
            yield return null;
        }
        Debug.Log("Object 생성");
        yield return Object.Instantiate(request.asset as GameObject);
        
    }

    
}
