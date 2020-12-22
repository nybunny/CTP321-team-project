using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/UpperRoom/ShowWineSet")]
public class ShowWineSet : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject bottle = GameObject.Find("WineSet").transform.GetChild(0).gameObject;
        GameObject glass = GameObject.Find("WineSet").transform.GetChild(1).gameObject;
        bottle.SetActive(true);
        glass.SetActive(true);
       // GameObject dialogue2 = GameObject.Find("DialogueManager").transform.GetChild(1).gameObject;
       // dialogue2.SetActive(true);
        return true;
    }
}
