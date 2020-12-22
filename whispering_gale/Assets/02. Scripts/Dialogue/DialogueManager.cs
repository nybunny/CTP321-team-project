using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> speakers;
    public Queue<string> sentences;
    public Queue<Sprite> pictures;
    
    public List<QuestAction> startActions;
    public List<QuestAction> endActions;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image imageBox;
    public GameObject dialogueBox;

    public Animator animator;
    private NextAction nextAction;


    private void DoActions(List<QuestAction> Actions) // acitons that start simultaneously with the quest
    {
        foreach (QuestAction act in Actions)
        {
            act.ExecuteRole();
        }
    }
    
    // Start is called before the first frame update
    void OnEnable()
    {
        speakers = new Queue<string>();
        sentences = new Queue<string>();
        pictures = new Queue<Sprite>();
    }

    public void StartDialogue (Dialogue dialogue, Images images, bool hasImages, NextAction next)
    {
        dialogueText.text = "";
        DoActions(startActions);
        //Debug.Log("Starting conversation with " + dialogue.name); Debug.Log(next.nextSceneName);
        nextAction = next;
        //animator.SetBool("IsOpen", true);
        dialogueBox.SetActive(true);

        //nameText.text = dialogue.name;

        speakers.Clear();
        sentences.Clear();
        pictures.Clear();
        
        foreach (string speaker in dialogue.speakers)
        {
            speakers.Enqueue(speaker);
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

       // Debug.Log("Image");
        if (hasImages)
        {
            foreach (Sprite picture in images.images)
                pictures.Enqueue(picture);
        }

        nameText.text = dialogue.speakers[0];

        if (hasImages)
            DisplayNextImage();

        StartCoroutine(delay(0.65f));
    }

    private IEnumerator delay(float time)
    {
        yield return new WaitForSeconds(time);
        //Debug.Log("delayed");
        DisplayNextSentence();
    }

    public void delayedDialogue(float time, int dialogueNum)
    {
        StartCoroutine(delayed2(time, dialogueNum));
    }

    private IEnumerator delayed2(float time, int dialogueNum)
    {
        yield return new WaitForSeconds(time);
        GameObject dialogue = transform.GetChild(dialogueNum).gameObject;
        dialogue.SetActive(true);
        dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
    

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (speakers.Count != 0)
        {
            string speaker = speakers.Dequeue();
            nameText.text = speaker;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        //dialogueText.text = sentence;
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayNextImage()
    {
        if (pictures.Count == 0)
            return;
        Sprite i = pictures.Dequeue();
        imageBox.sprite = i;
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        NextAction(nextAction);
    }

    // what to do at the end of dialogue (NextAction.cs 참고)
    public void NextAction(NextAction next)
    {
        int actionCode = next.nextActionCode;
        if (actionCode >= 0)
        {
            StopAllCoroutines();
            dialogueBox.SetActive(false); DoActions(endActions); }
        else actionCode = actionCode * (-1);

        switch (actionCode)
        {
            case 0: return; //break;
            case 1: SceneManager.LoadScene(next.nextSceneName); break;  //load scene
            case 2: next.nextObject.GetComponent<QuestTrigger>().TriggerQuest(); break;     //trigger quest
            case 3: next.nextObject.GetComponent<DialogueTrigger>().TriggerDialogue(); break;   //trigger dialogue
            case 4:
                foreach (QuestAction act in next.effect)
                {
                    act.ExecuteRole();
                }
                break;   //execute action
            case 5: next.nextObject.SetActive(true); break;
            case 6:
                next.nextObject.GetComponent<QuestTrigger>().QuestCompleted();
                break;
        }
    }
}
