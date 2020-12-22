using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public GameObject questUI;
    public AudioSource audio;
    //public GameObject questSave;

    public void StartQuest(QuestData quest)
    {
        //show the quest's objective on-screen
        //Debug.Log(quest.questNumber);
        //Debug.Log(quest.questName);
        quest.hasStarted = true;
        quest.StartActions();
        questUI.GetComponent<QuestDisplay>().activeNum += 1;
        //questSave.GetComponent<QuestSaveData>().SaveQuestStarted(quest.questNumber);
        ShowQuestInfo(quest);
    }

    void ShowQuestInfo(QuestData quest)
    {
      //  Debug.Log(quest.questName);
      //  Debug.Log(quest.questContent);
        questUI.GetComponent<QuestDisplay>().DisplayNewQuest(quest); //function that shows player the quest infos
    }

    //function that's activated when the quest is finished (usually attached to specified object)
    public void QuestCompleted(QuestData quest)
    {
        quest.hasStarted = false;
        questUI.GetComponent<QuestDisplay>().activeNum -= 1;
        //   questSave.GetComponent<QuestSaveData>().SaveQuestCompleted(quest.questNumber);
        audio.enabled = false;
        audio.enabled = true;
        quest.EndQuest();
    }
}
