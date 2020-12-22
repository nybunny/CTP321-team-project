using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOnInteractions")]
public class TurnOnInteractions : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("Louis").GetComponent<Louis_Interaction>().enabled = true;
        return true;
    }
}
