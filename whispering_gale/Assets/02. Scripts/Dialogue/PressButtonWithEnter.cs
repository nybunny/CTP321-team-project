using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButtonWithEnter : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            button.onClick.Invoke();

    }


}
