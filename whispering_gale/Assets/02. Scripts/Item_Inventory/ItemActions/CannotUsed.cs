using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ItemEft/CannotUsed")]
public class CannotUsed : ItemEffect
{
    public override bool ExecuteRole()
    {
        return false;
    }
}
