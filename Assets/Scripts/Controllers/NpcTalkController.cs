using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class NpcTalkController : MonoBehaviour
{
    bool TalkCeck;
    private Quaternion rot;
    public GameObject taget { get; set; }
    private int index = 1;
    
    private void Start()
    {
        rot = transform.parent.rotation;
    }

    private void Update()
    {
        if (TalkCeck)
            transform.parent.LookAt(taget.transform);
        else
            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation ,rot,10 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject Talk = GameObject.Find("MainCanvas").transform.Find("Talk").gameObject;
        Talk.SetActive(true);
        
        Talk.transform.Find("NpcName").transform.Find("Text").GetComponent<Text>().text
            = transform.parent.GetComponent<NpcData>().npcName;
        Talk.transform.Find("TalkBoard").transform.Find("Text").GetComponent<Text>().text
            = transform.parent.GetComponent<NpcData>().talks[0];
        TalkCeck = true;
        taget = other.gameObject;
        Talk.transform.Find("Button").GetComponent<Button>().onClick.AddListener(NextTalk);
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject Talk = GameObject.Find("MainCanvas").transform.Find("Talk").gameObject;
        Talk.transform.Find("Button").GetComponent<Button>().onClick.RemoveListener(NextTalk);
        Talk.SetActive(false);
        TalkCeck = false;
        index = 1;
    }

    public void NextTalk()
    {
        GameObject Talk = GameObject.Find("MainCanvas").transform.Find("Talk").gameObject;
        if (transform.parent.GetComponent<NpcData>().talks.Count > index)
        {
            Talk.transform.Find("TalkBoard").transform.Find("Text").GetComponent<Text>().text 
                = transform.parent.GetComponent<NpcData>().talks[index++];
        }
        else
        {
            Talk.SetActive(false);
        }
        
        
    }
}
