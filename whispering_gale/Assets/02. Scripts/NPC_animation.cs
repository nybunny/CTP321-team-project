using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
    IDLE,
    TALK
}

public class NPC_animation : MonoBehaviour
{
    public STATE state = STATE.IDLE;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //if (state == STATE.IDLE) -> 숨쉬기 운동
    }
}
