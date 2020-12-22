using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOnMoving")]
public class TurnOnMoving : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("Louis").GetComponent<Louis_Controller>().enabled = true;
        return true;
    }
}