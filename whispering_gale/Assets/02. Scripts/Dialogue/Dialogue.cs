using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //public int dialogueNum;
    //public string dialogueName;

    public string[] speakers;
    [TextArea(3, 30)] //minimum & maximum number of lines TextArea will use
    public string[] sentences;
}
