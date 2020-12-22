using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMovingScript : MonoBehaviour
{
    public Louis_Controller controller;

    public void EnableMoving(float time)
    {
        StartCoroutine(delayedEnable(time));
    }

    private IEnumerator delayedEnable(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("Source").GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Source").GetComponent<AudioListener>().enabled = false;
        GameObject.Find("Camera").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Camera").GetComponent<AudioListener>().enabled = true;
        controller.enabled = true;
    }
}