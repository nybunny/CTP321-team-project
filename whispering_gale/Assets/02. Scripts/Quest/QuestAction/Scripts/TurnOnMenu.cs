using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOnMenu")]
public class TurnOnMenu : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("UI").GetComponent<Inventory>().enabled = true;
        GameObject.Find("Menu").GetComponent<Button>().interactable = true;
        return true;
    }
}