using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ItemEft/Consumable/Eat")]
public class Eat : ItemEffect
{
    public float amount;
    public override bool ExecuteRole()
    {
        GameObject.Find("Louis_Health").GetComponent<Louis_Health>().eat(amount);
        return false;
    }
}
