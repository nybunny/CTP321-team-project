using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestAction/house/statuschange")]
public class StatusChange : QuestAction
{
    public int status;
    public override bool ExecuteRole()
    {
        GameObject.Find("Louis").GetComponent<Louis_Interaction>().status = status;
        return true;
    }
}
