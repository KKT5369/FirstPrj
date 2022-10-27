using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkController : MonoBehaviour
{
    [SerializeField] public Text _npcName;
    [SerializeField] public Text _npcTalk;
    [SerializeField] public Button _nextTalk;
    private int index = 0;

    public void TextBorad(string name,List<string> talkList)
    {
        _npcName.text = name;
        _npcTalk.text = talkList[index++];
        _nextTalk.onClick.AddListener(() => NextTalk(talkList));
    }
    
    void NextTalk(List<string> talkList)
    {
        if ( talkList.Count > index)
        {
            _npcTalk.text = talkList[index++];
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    
}
