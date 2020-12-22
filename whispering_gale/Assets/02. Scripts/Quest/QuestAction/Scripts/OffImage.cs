using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOffImage")]
public class OffImage : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("Image1").SetActive(false);
        return true;
    }
}

