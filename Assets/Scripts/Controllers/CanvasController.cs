using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject Talk;
    public Collider _other { get; set; }
    private int index;

    private void Start()
    {
        Talk = transform.Find("Talk").gameObject;
    }

    private void Update()
    {
        Manager.Canvas._npcTalk -= NpcTalk;
        Manager.Canvas._npcTalk += NpcTalk;
        Manager.Canvas._npcTalkEnd -= EndTalk;
        Manager.Canvas._npcTalkEnd += EndTalk;
    }

    void NpcTalk(Collider othrt)
    {
        this._other = othrt;
        NpcData data = _other.GetComponent<NpcData>();
        if (data == null) return;
        Talk.SetActive(true);

        Talk.transform.Find("NpcName").transform.Find("Text").GetComponent<Text>().text
            = _other.GetComponent<NpcData>().npcName;
        Talk.transform.Find("TalkBoard").transform.Find("Text").GetComponent<Text>().text
            = _other.GetComponent<NpcData>().talks[0];
        Talk.transform.Find("Button").GetComponent<Button>().onClick.AddListener(NextTalk);
    }
    void NextTalk()
    {
        if (_other.GetComponent<NpcData>().talks.Count > index)
        {
            Talk.transform.Find("TalkBoard").transform.Find("Text").GetComponent<Text>().text
                = _other.GetComponent<NpcData>().talks[index++];
        }
        else
        {
            Talk.SetActive(false);
        }
    }

    void EndTalk()
    {
        Talk.transform.Find("Button").GetComponent<Button>().onClick.RemoveListener(NextTalk);
        Talk.SetActive(false);
        index = 1;
    }

}
