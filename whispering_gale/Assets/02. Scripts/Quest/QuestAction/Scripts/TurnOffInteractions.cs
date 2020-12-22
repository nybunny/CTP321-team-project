using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOffInteractions")]
public class TurnOffInteractions : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject Louis = GameObject.Find("Louis");
        if (Louis != null) Louis.GetComponent<Louis_Interaction>().enabled = false;
        return true;
    }
}