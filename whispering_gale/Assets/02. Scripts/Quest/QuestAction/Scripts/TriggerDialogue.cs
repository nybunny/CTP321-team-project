using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/TriggerDialogue")]
public class TriggerDialogue : QuestAction
{
    public int dialogueNum;
    public override bool ExecuteRole()
    {
        GameObject dialogue2 = GameObject.Find("DialogueManager").transform.GetChild(dialogueNum).gameObject;
        dialogue2.SetActive(true);
        dialogue2.GetComponent<DialogueTrigger>().TriggerDialogue();
        return true;
    }
}
