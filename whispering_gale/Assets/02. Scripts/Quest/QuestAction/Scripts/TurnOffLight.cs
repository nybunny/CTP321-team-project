using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOffLight")]
public class TurnOffLight : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject lights = GameObject.Find("Lights");
        lights.transform.GetChild(0).gameObject.SetActive(true);
        lights.transform.GetChild(1).gameObject.SetActive(false);
        return true;
    }
}