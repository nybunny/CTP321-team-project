using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ItemEft/ItemDialogue")]
public class ItemDialogue : ItemEffect
{
    public int dialogueNum;
    public override bool ExecuteRole()
    {
        GameObject dialogue = GameObject.Find("ItemDialogue").transform.GetChild(dialogueNum).gameObject;
        dialogue.SetActive(true);
        dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
        return true;
    }
}
