using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class TestBox : MonoBehaviour
{
    private GameObject go;
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("CreatChost");
    }

    IEnumerator CreatChost()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(3f);
            yield return go = Manager.Resource.Instantiate<GameObject>("Ghost");
        }
    }
}
