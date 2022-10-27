using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        NpcData data = other.GetComponent<NpcData>();
        if (other.CompareTag("NPC") && data.talks != null)
        {
            string name = data.npcName;
            List<string> talkList = data.talks;
            Manager.UI.CreatTalk(name,talkList);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Manager.UI.KillTalk();
    }
}
