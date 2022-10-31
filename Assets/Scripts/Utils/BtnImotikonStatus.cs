using UnityEngine;


public class BtnImotikonStatus : MonoBehaviour
{
    [SerializeField]
    public int _imotikonNum;

    public void Test()
    {
        Debug.Log($"{_imotikonNum} 번째 버튼을 클릭!!");
    }

}
