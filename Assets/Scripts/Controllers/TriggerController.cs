using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            NpcData data = other.GetComponent<NpcData>();
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
