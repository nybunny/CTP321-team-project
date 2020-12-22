using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestAction/Quest11/MouseyDance")]
public class Q11_MouseyDance : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject mouse = GameObject.Find("mousy");
        mouse.GetComponent<Mousey_Controller>().AfterDialogue();
        Debug.Log("sanity check: dialogue3 complete!");
        return true;
    }
}
