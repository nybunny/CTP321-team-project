using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReminiscenceTrigger : MonoBehaviour
{
    public DialogueTrigger dialogue;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dialogue.TriggerDialogue();
            this.gameObject.SetActive(false);
        }
    }
}
