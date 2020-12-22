using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOffInventory")]
public class TurnOffInventory : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject inventory = GameObject.Find("Inventory");
        GameObject tooltip = GameObject.Find("BaseOuter");
        if (tooltip != null) tooltip.SetActive(false);
        if (inventory != null) inventory.SetActive(false);
        return true;
    }
}
