using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    // 필수
    public int questNumber;
    public string questName;

    [TextArea(3, 10)]
    public string questContent;
    public bool hasStarted; //기본적으로 false로 맞춰두기
    public bool completed;
   // public NextAction nextAction;

    public List<QuestAction> startActions;
    public List<QuestAction> endActions;

    // 선택
    public int[] npcId; //npc(s) Louis may interact with
    //public GameObject dialogue;

    public QuestData(string name, int[] npc)
    {
        questName = name;
        npcId = npc;
        hasStarted = false;
    }

    public bool StartActions() // acitons that start simultaneously with the quest
    {
        bool done = true;
        foreach (QuestAction act in startActions)
        {
            done = done && act.ExecuteRole();
        }
        return done;
    }

    public bool EndQuest()
    {
        bool done = true;
        foreach (QuestAction act in endActions)
        {
            done = done && act.ExecuteRole();
        }
      //  Debug.Log(questName);
        return done;
    }

}