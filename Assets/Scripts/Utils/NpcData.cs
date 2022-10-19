using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class NpcData : MonoBehaviour
{
    [SerializeField]
    private int codeId;
    public string npcName { get; private set; }
    public List<string> talks { get; private set; }
    
    private void Start()
    {
        try
        {
            TextAsset jsonResponse = Resources.Load("Json/npcData") as TextAsset;
            NpcJsonDataArr dataArr = JsonUtility.FromJson<NpcJsonDataArr>(jsonResponse.ToString());
            
            foreach (NpcJsonData arr in dataArr.data)
            {
                if (arr.codeId == codeId)
                {
                    npcName = arr.npcName;
                    talks = arr.talk;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Debug.Log("json 정보를 불러 오는중에 오류 발생");
            throw;
        }
    }
}

[Serializable]
public class NpcJsonData
{
    public int codeId;
    public string npcName;
    public List<string> talk;
    
}

[Serializable]
public class NpcJsonDataArr
{
    public NpcJsonData[] data;
}
