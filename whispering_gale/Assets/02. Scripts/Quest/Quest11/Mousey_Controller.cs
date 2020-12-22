using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousey_Controller : MonoBehaviour
{
    private Animator anim;
    private GameObject louis;
    private bool hasTalked;

    public GameObject dialogue3;
    //public string player_name;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        louis = GameObject.Find("Louis");
        hasTalked = false; //세이브 파일이 없으니까
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "Louis") && (!hasTalked) && (FindQuest11Value() == 1))
        {
            hasTalked = true;
            Vector3 newDirection = transform.position - louis.transform.position;
            transform.rotation = Quaternion.LookRotation(-newDirection);
            louis.transform.rotation = Quaternion.LookRotation(newDirection);
            dialogue3.GetComponent<DialogueTrigger>().TriggerDialogue();
            WhenDialogueStarts();
        }
    }

    private int FindQuest11Value()
    {
        return louis.GetComponent<Louis_Controller>().quest11;
    }

    /*
    private int FindQuest11Value() // 0 if quest11 hasn't started, 1 if quest11 has started, 2 if quest11 has ended
    {
        if (PlayerPrefs.HasKey(PlayerPrefs.GetInt(player_name).ToString() + "_quest11"))
            return PlayerPrefs.GetInt(PlayerPrefs.GetInt(player_name).ToString() + "_quest11");
        else
            return 0;
    }
    */
    private void WhenDialogueStarts()
    {
        anim.SetBool("D3_started", true);
    }
    public void AfterDialogue()
    {
        anim.SetBool("D3_done", true);
    }

}
