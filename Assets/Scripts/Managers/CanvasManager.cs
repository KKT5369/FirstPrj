using System;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager
{
    public Action<Collider> _npcTalk;
    public Action _npcTalkEnd;

    public void TalkStart(Collider other)
    {
        _npcTalk.Invoke(other);
    }

    public void TalkEnd()
    {
        _npcTalkEnd.Invoke();
    }
    
}
