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
        // TODO 제넥릭 타입은 T 로받고 Load와  Instantiate 분리.
        ResourceRequest request = Resources.LoadAsync<GameObject>($"Frefabs/{path}");
        
        while (!request.isDone)
        {
            yield return null;
        }
        
        if (request.asset == null)
        {
            Debug.Log($"gameObject not Find [path name is {path}]");
            yield break;
        }
        
        
        // typeof 체크해서 gameobject만 생성...
        Debug.Log("Object 생성");
        yield return Object.Instantiate(request.asset as GameObject);
        
    }

    
}
