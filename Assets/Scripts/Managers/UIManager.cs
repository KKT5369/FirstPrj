using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    private GameObject _canvas;
    private GameObject _talk;
    private Text _npcName;
    private Text _NpcTalk;
    private NpcData _npcInfo;
    private int index = 0;

    // MainCanvas 생성.
    public void Init()
    {
        if (_canvas.IsUnityNull())
        {
            var gm = Resources.Load<GameObject>("Prefabs/MainCanvas");
            _canvas = Object.Instantiate(gm);
        }
    }
    
    // npc 트리거 이벤트 발동시 실행.
    public void CreatTalk(Collider other)
    {
        // npc와 트리거 이벤트 발생시 Prefab에서 Talk 생성
        if (_talk.IsUnityNull())
        {
            GameObject talk = Resources.Load<GameObject>("Prefabs/Talk");
            _talk = Object.Instantiate(talk, _canvas.transform);
        }
        
        if(other == null) return;
        
        // Talk UI 에 npc이름과 대화내용을 출력
        _npcName = _talk.transform.Find("NpcName").transform.Find("Text").GetComponent<Text>();
        _NpcTalk = _talk.transform.Find("TalkBoard").transform.Find("Text").GetComponent<Text>();
        _npcInfo = other.GetComponent<NpcData>();
        
        _npcName.text = _npcInfo.npcName;
        _NpcTalk.text = _npcInfo.talks[index++];
        
        // 클릭 이벤트 발생시 다음 대화 출력.
        _talk.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => NextTalk(other));
    }
    
    // 트리거 영역을 벗어나면 실행.
    public void KillTalk()
    {
        // TODO 대화를 끝내는 로직
        if (!_talk.IsUnityNull())
        {
            Object.Destroy(_talk);
        }
        index = 0;
    }
    
    // 클릭 이벤트 발생시 실행.
    void NextTalk(Collider other)
    {
        if (other.GetComponent<NpcData>().talks.Count > index)
        {
            _NpcTalk.text = other.GetComponent<NpcData>().talks[index++];
        }
        else
        {
            Object.Destroy(_talk);
        }
    }
}
