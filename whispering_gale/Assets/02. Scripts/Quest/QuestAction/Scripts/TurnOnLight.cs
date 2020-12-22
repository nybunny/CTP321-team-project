using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOnLight")]
public class TurnOnLight : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject lights = GameObject.Find("Lights");
        lights.transform.GetChild(0).gameObject.SetActive(false);
        lights.transform.GetChild(1).gameObject.SetActive(true);
        return true;
    }
}