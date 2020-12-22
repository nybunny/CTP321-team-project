using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest1 : MonoBehaviour
{

    private bool done;
    private float keyWPressTime;

    public GameObject questManager;

    // Start is called before the first frame update
    void Start()
    {
        keyWPressTime = 0.0f;
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (done) return;

        if (keyWPressTime > 3.0f)
        {
            done = true;
          //  Debug.Log("walkingquestdone");
            questManager.GetComponent<QuestManager>().QuestCompleted(this.gameObject.GetComponent<QuestTrigger>().quest);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            keyWPressTime += Time.deltaTime;
        }

        //Debug.Log(keyWPressTime);
    }
}
