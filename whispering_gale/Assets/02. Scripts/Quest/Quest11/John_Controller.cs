using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John_Controller : MonoBehaviour
{
    //public string player_name;
    public GameObject louis;
    public DialogueTrigger dialogue5;

    private Transform johnTr;
    private Animator anim;

    private bool quest11_done; // true if complete, false if incomplete

    // Start is called before the first frame update
    void Start()
    {
        johnTr = this.GetComponent<Transform>();
        anim = GetComponent<Animator>();

        quest11_done = false;

        if (louis.GetComponent<Louis_Controller>().quest11 == 2)
            quest11_done = true;
        /*
        if (PlayerPrefs.HasKey(PlayerPrefs.GetInt(player_name).ToString() + "_quest11"))
            if (PlayerPrefs.GetInt(PlayerPrefs.GetInt(player_name).ToString() + "_quest11") == 2)
                quest11 = true;
        */
        if (quest11_done)
            anim.SetBool("IsHappy", true); // OR change the layer default state to idle
    }

    public void BeforeDialogue4(GameObject louis)
    {
        // turn to face Louis
        johnTr = GetComponent<Transform>();
        Vector3 newDirection = transform.position - louis.transform.position;
        transform.rotation = Quaternion.LookRotation(-newDirection);
        louis.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void AfterDialogue4()
    {
        //John walks away
        transform.rotation = Quaternion.LookRotation(transform.position - louis.transform.position); //johnTr.rotation;
        anim.SetBool("D4_done", true);
        StartCoroutine("walker");
        //this.gameObject.SetActive(false);

        //Start dialogue5
        dialogue5.TriggerDialogue();
    }

    IEnumerator walker()
    {
        yield return new WaitForSeconds(10);
        anim.SetBool("D4_done", false);
    }

}
