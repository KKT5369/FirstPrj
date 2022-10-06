using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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