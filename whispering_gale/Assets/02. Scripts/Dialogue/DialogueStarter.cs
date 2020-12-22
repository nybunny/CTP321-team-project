using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueStarter : MonoBehaviour
{
    //Script that starts the dialogue
    void Start()
    {
        this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

}
