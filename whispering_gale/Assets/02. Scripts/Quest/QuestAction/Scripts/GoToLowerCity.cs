using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "QuestAction/UpperRoom/GoToLowerCity")]
public class GoToLowerCity : QuestAction
{
    public override bool ExecuteRole()
    {
        SceneManager.LoadScene("LowCity1");
        return true;
    }
}
