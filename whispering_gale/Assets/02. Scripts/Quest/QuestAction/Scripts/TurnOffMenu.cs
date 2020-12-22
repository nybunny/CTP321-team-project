using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOffMenu")]
public class TurnOffMenu : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("UI").GetComponent<Inventory>().enabled = false;
        GameObject.Find("Menu").GetComponent<Button>().interactable = false;
        GameObject Acts = GameObject.Find("Actions");
        if (Acts != null) Acts.SetActive(false);
        return true;
    }
}