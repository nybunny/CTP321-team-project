using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAnimation : MonoBehaviour
{
    private Animator animator;
    private float xi, zi;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsRun", true);
        xi = transform.position.x;
        zi = transform.position.z;
        counter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Abs(transform.position.x - xi) > 10.0f) || (Mathf.Abs(transform.position.z - zi) > 10.0f))
        {
            this.gameObject.transform.Rotate(0.0f, Random.Range(70f, 110f), 0.0f);
        }
        else if (animator.GetBool("IsRun"))
        {
            int x = Random.Range(1, 40);
            if (x == 10)
            {
                animator.SetBool("IsRun", false);
                counter = 0.0f;
            }
            else if (x == 13)
            {
                animator.SetBool("IsDead", true);
                counter = 0.0f;
            }
        }
        else if (counter > 2.5f)
        {
            animator.SetBool("IsRun", true);
            animator.SetBool("IsDead", false);
        }
        counter += Time.deltaTime;
            
    }
}
