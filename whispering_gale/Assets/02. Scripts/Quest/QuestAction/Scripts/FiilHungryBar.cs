using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/FiilHungry")]
public class FiilHungryBar : QuestAction
{
    public float amount;
    public override bool ExecuteRole()
    {
        GameObject.Find("Louis_Health").GetComponent<Louis_Health>().eat(amount);
        return true;
    }
}
