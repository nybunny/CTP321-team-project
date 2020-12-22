using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest2 : MonoBehaviour
{

    private bool done;
    private float shiftPressTime;

    public QuestManager questManager;

    // Start is called before the first frame update
    void Start()
    {
        shiftPressTime = 0.0f;
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (done) return;
        if ((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Input.GetKey(KeyCode.W))
        {
            shiftPressTime += Time.deltaTime;
        }
        
        if (shiftPressTime > 3.0f)
        {
            done = true;
           // Debug.Log("running Quest done");
            questManager.GetComponent<QuestManager>().QuestCompleted(this.gameObject.GetComponent<QuestTrigger>().quest);
        }
    }
}
