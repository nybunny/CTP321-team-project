using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOnInventory")]
public class TurnOnInventory : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject inventory = GameObject.Find("UI");
        inventory.transform.GetChild(1).gameObject.SetActive(true);
        return true;
    }
}
