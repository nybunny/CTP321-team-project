using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestAction/Stun")]
public class Stun : QuestAction
{
    private Animator animator;
    public Material mat;

    public override bool ExecuteRole()
    {
        animator = GameObject.Find("Louis").GetComponent<Animator>();
        animator.SetBool("Stun", true);
        GameObject.Find("Camera").GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Source").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Source").GetComponent<AudioListener>().enabled = true;
        GameObject.Find("Camera").GetComponent<AudioListener>().enabled = false;
        GameObject.Find("LouisSpot").GetComponent<Light>().enabled = true;
        mat.color = Color.blue;
        return true;
    }
}

