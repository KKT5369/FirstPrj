using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager
{
    private GameObject _canvas;
    private GameObject _talk;

    // MainCanvas 생성.
    public void Init()
    {
        if (_canvas == null)
        {
            var gm = Resources.Load<GameObject>("Prefabs/MainCanvas");
            _canvas = Object.Instantiate(gm);
        }
    }
    
    // 대화창 UI 생성
    public void CreatTalk(string name,List<string> talkList)
    {
        // npc와 트리거 이벤트 발생시 Prefab에서 Talk 생성
        if (_talk == null)
        {
            GameObject talk = Resources.Load<GameObject>("Prefabs/Talk");
            _talk = Object.Instantiate(talk, _canvas.transform);
        }

        _talk.GetComponent<TalkController>().TextBorad(name, talkList);

    }
    
    // 대화창 UI 삭제
    public void KillTalk()
    {
        if (!_talk.IsUnityNull())
        {
            Object.Destroy(_talk);
        }
    }
}
