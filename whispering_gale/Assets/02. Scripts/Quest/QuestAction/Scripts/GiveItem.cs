using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/UpperRoom/GiveItem")]
public class GiveItem : QuestAction
{
    public int index;
    public override bool ExecuteRole()
    {
       // Debug.Log(index);
        Inventory.instance.AddItem(index);
        return true;
    }
}

