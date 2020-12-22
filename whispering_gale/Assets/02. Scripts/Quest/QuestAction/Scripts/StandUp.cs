using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestAction/StandUp")]
public class StandUp : QuestAction
{
    public float time;
    public override bool ExecuteRole() {
        GameObject.Find("Louis").GetComponent<Animator>().SetBool("Stun", false);
        GameObject.Find("Louis").GetComponent<EnableMovingScript>().EnableMoving(time);
        return true;
    }
}
