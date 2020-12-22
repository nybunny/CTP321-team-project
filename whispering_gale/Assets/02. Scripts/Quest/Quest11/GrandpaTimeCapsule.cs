using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandpaTimeCapsule : MonoBehaviour
{
    public GameObject tower;
    public GameObject dialogue;

    private void OnEnable() //called when the attached GameObject is toggled
    {
        tower.GetComponent<Light>().enabled = true;
        tower.GetComponent<Light>().color = Color.blue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Louis")
        {
            SceneManager.LoadScene("Epilogue");
        }
           // dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
