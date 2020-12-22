using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/WakeUp")]
public class Wakeup : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("Louis").GetComponent<Louis_Interaction>().WakeUp();
        return true;
    }
}