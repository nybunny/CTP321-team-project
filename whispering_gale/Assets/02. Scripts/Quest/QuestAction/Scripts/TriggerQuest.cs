using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/TriggerQuest")]
public class TriggerQuest: QuestAction
{
    public int QuestNum;
    public override bool ExecuteRole()
    {
        GameObject quest = GameObject.Find("QuestManager").transform.GetChild(QuestNum).gameObject;
        quest.GetComponent<QuestTrigger>().TriggerQuest();
        return true;
    }
}
