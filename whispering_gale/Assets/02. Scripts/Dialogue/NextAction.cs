using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NextAction
{
    public int nextActionCode;
    /*
    0: no next action
    1: change scene
    2: start quest
    3: start dialogue
    4:
    5: nextObject.SetActive(true)
    */
    public GameObject nextObject; //다음 action에 필요한 스크립트(ex) DialogueTrigger.cs, QuestTrigger.cs)가 있는 GameObject
    public List<QuestAction> effect;

    // nextActionCode의 값에 따라 얘네 중 하나만 있으면 됨
    public string nextSceneName;
    public int nextQuestNum; //starts from 1, 0 if nextActionCode != 2
    //public Dialogue dialogue; 필요 없음
}
