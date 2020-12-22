using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDialogueTrigger : MonoBehaviour
{
    public GameObject dialogue;
    //public string player_name; //임시용
    //public QuestSaveData questSave;
    private GameObject louis;

    /*
    private void Awake()
    {
        PlayerPrefs.DeleteKey(PlayerPrefs.GetInt(player_name).ToString() + "_quest11");
    }
    */

    void Start()
    {
        louis = GameObject.Find("Louis");
        louis.GetComponent<Louis_Controller>().quest11 = 0; // 세이브 파일은 없으니까
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Louis")
        {
            if (louis.GetComponent<Louis_Controller>().quest11 == 0)
            {
                Vector3 newDirection = transform.position - louis.transform.position;
                transform.rotation = Quaternion.LookRotation(-newDirection);
                louis.transform.rotation = Quaternion.LookRotation(newDirection);
                this.GetComponent<Light>().enabled = false;
                dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
                //questSave.SaveQuestStarted(11);
            }
                
        }
        louis.GetComponent<Louis_Controller>().quest11 = 1;
        Debug.Log(louis.GetComponent<Louis_Controller>().quest11);
    }
}
