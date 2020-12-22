using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/OnOff/QuestCompleted")]
public class QuestCompleted : QuestAction
{
    public int QuestNum;
    public override bool ExecuteRole()
    {
        GameObject Quests = GameObject.Find("QuestManager");
        Quests.transform.GetChild(QuestNum).GetComponent<QuestTrigger>().QuestCompleted();
        return true;
    }
}