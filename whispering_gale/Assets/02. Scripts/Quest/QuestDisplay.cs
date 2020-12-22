using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    private string[] questNames;
    private Dictionary<int, QuestData> allQuests;

    [SerializeField]
    private GameObject [] questObjects;

    [SerializeField]
    private GameObject questinfo;
    [SerializeField]
    private GameObject questTitle;
    [SerializeField]
    private GameObject questContent;
    [SerializeField]
    private GameObject questButton;

    private bool QuestShown = true;
    private bool QuestActive = true;

    //public string test;
    public int activeNum; //number of active quests

    private void Start()
    {
        allQuests = new Dictionary<int, QuestData>();
        activeNum = 0;
        foreach (GameObject quest in questObjects)
        {
            QuestTrigger q = quest.GetComponent<QuestTrigger>();
            allQuests.Add(q.quest.questNumber, q.quest);
            if (q.quest.hasStarted == true)
            {
                activeNum += 1;
                FindObjectOfType<QuestManager>().StartQuest(q.quest);
            }
        }
    }

    private void QuestActivate(bool active)
    {
        questinfo.SetActive(active);
        questButton.SetActive(active);
        QuestActive = active;
        QuestShown = active;
    }

    private void Update()
    {
        if (activeNum > 0 && !QuestActive) QuestActivate(true); 
        if (activeNum == 0 && QuestActive) QuestActivate(false);
        if (activeNum > 0 && Input.GetKeyDown("q")) QuestButtonClick();
        //   if (activeNum > 0) QuestActivate(true);
        //    else if (activeNum < 0)
        //         activeNum = 0; //just-in-case
        //    else QuestDisactivate(false);
        //Debug.Log(activeNum);
    }

    public void DisplayNewQuest(QuestData quest)
    {
        QuestActivate(true);
        questTitle.GetComponent<TextMeshProUGUI>().text = quest.questName;
        questContent.GetComponent<TextMeshProUGUI>().text = quest.questContent;
    }
    
    public void HideGameObject(GameObject toHide)
    {
        toHide.SetActive(false);
    }

    public void QuestButtonClick()
    {
        if (QuestShown)
        {
            questinfo.SetActive(false);
            QuestShown = false;
        }
        else
        {
            questinfo.SetActive(true);
            QuestShown = true;
        }
    }
}
/* 메모
 activeNum - Scene이 열리자마자 시작되는 퀘스트 기록용
            (& 동시에 여러 퀘스트를 받을 수 있도록 프로그램 할 때 대비) -> 아직은 구현 안 함.

 */