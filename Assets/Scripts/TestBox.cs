using System;
using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class TestBox : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
        StartCoroutine("CreatChost");
    }

    IEnumerator CreatChost()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(3f);
            Manager.Resource.Instantiate<GameObject>("Ghost");
        }
    }
    

    
}
