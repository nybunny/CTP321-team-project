using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/DelayedDialogue")]
public class DelayedDialogue : QuestAction
{
    public int dialogueNum;
    public int time;

    public override bool ExecuteRole()
    {
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().delayedDialogue(time, dialogueNum);
        return true;
    }
}
