using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Louis_Health : MonoBehaviour
{
    public Image hungryBar;
    public Image sleepyBar;

    public float speed = 0.05f;
    public float currentHunger = 0.0f;
    public float maxHunger = 30.0f; //마지막으로 세이브 했을 때의 데이터 값을 어떻게 가져오는지는 나중에...
    private float prevHunger = 0.0f;

    public float currentSleepy = 0.0f;
    public float maxSleepy = 100.0f;
    private float prevSleepy = 0.0f;
    // hungry / sleepy 함수들을 각자 다른 스크립트에 쓸까? -> 상관없지 않을까?

    public Animator animator;
    private int sleeping;

void Start()
    {
        currentHunger = maxHunger;
        prevHunger = maxHunger;

        currentSleepy = maxSleepy;
        prevSleepy = maxSleepy;
        
        sleeping = 0;
    }

    void Update()
    {
        if (currentHunger > 0.0f)
        {
            currentHunger = prevHunger - speed * Time.deltaTime;
            hungryBar.fillAmount = currentHunger / maxHunger;
            prevHunger = currentHunger;
        }

        if (sleeping == 0 && currentSleepy > 0.0f)
        {
            currentSleepy = prevSleepy - speed * Time.deltaTime;
            prevSleepy = currentSleepy;
            sleepyBar.fillAmount = currentSleepy / maxSleepy;
        }
        else
        {
            sleeping++;
            currentSleepy = prevSleepy + 3 * Time.deltaTime;
            prevSleepy = currentSleepy;
            sleepyBar.fillAmount = currentSleepy / maxSleepy;
            if (currentSleepy >= maxSleepy || sleeping == 1000)
            {
                currentSleepy = maxSleepy;
                animator.SetBool("IsSleep", false);
                sleeping = 0;
            }
        }
    }

    public void eat(float amount)
    {
        currentHunger = prevHunger + amount;
        if (currentHunger > maxHunger) currentHunger = maxHunger;
        prevHunger = currentHunger;
        hungryBar.fillAmount = currentHunger / maxHunger;
    }


    public void Sleep()
    {
        if (sleeping == 0)
        {
            animator.SetBool("IsSleep", true);
            sleeping = 1;
        }
    }

    public void Hotel()
    {
        Sleep();
    }
}
