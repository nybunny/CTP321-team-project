using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ItemEft/NonConsumable/Wrapper")]
public class CandyWrapper : ItemEffect
{
    public override bool ExecuteRole()
    {
        Debug.Log("Wrapper");
        return false;
    }
}
