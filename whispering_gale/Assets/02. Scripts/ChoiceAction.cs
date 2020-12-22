using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceAction : MonoBehaviour
{
    public List<QuestAction> actions;

    public void doActions()
    {
        StartCoroutine(done()); 
    }

    private IEnumerator done()
    {
        yield return new WaitForSeconds(0.35f);
        transform.parent.gameObject.SetActive(false);
        foreach (QuestAction act in actions)
        {
            act.ExecuteRole();
        }
    }
}
