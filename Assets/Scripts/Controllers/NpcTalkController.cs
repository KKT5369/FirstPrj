using UnityEngine;
using UnityEngine.UI;

public class NpcTalkController : MonoBehaviour
{
    //bool TalkCheck;
    private Quaternion rot;
    private int index = 1;

    private void Start()
    {
        rot = transform.parent.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject Talk = GameObject.Find("MainCanvas").transform.Find("Talk").gameObject;
        Talk.SetActive(true);
        Talk.transform.Find("NpcName").transform.Find("Text").GetComponent<Text>().text
            = transform.parent.GetComponent<NpcData>().npcName;
        Talk.transform.Find("TalkBoard").transform.Find("Text").GetComponent<Text>().text
            = transform.parent.GetComponent<NpcData>().talks[0];
        //TalkCheck = true;
        Talk.transform.Find("Button").GetComponent<Button>().onClick.AddListener(NextTalk);
    }

    private void OnTriggerStay(Collider other)
    {
        transform.parent.LookAt(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation ,rot,1 * Time.deltaTime);
        GameObject Talk = GameObject.Find("MainCanvas").transform.Find("Talk").gameObject;
        Talk.transform.Find("Button").GetComponent<Button>().onClick.RemoveListener(NextTalk);
        Talk.SetActive(false);
        //TalkCheck = false;
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
