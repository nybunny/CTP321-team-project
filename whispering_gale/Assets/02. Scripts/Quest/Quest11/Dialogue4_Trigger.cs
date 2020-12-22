using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue4_Trigger : MonoBehaviour
{
    // attach to Dragon
    private GameObject louis, john;
    //private bool dia4; // false if dialogue4 hasn't started, true if it has started

    //public string player_name;
    public GameObject dialogue4;

    // Start is called before the first frame update
    void Start()
    {
        //dia4 = false; //세이브 기능이 없으니까...에휴
        louis = GameObject.Find("Louis");
        john = GameObject.Find("john");
        if (louis.GetComponent<Louis_Controller>().quest11 == 2)
            this.GetComponent<Dialogue4_Trigger>().enabled = false;
        /*
        if (PlayerPrefs.HasKey(PlayerPrefs.GetInt(player_name).ToString() + "_quest11"))
            if (PlayerPrefs.GetInt(PlayerPrefs.GetInt(player_name).ToString() + "_quest11") == 2)
                this.GetComponent<Dialogue4_Trigger>().enabled = false;
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        Dialogue4Time();
        this.GetComponent<BoxCollider>().enabled = false;
    }

    private void Dialogue4Time()
    {
        john.GetComponent<John_Controller>().BeforeDialogue4(louis);
        dialogue4.GetComponent<DialogueTrigger>().TriggerDialogue();
        //dia4 = true;
    }
}
