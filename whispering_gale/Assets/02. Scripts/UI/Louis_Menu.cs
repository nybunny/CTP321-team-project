using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Louis_Menu : MonoBehaviour
{

    public GameObject ActionMenu;
    public GameObject Inventory;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click_Louis_Button()
    {
        if (ActionMenu.activeSelf == true)
        {
            ActionMenu.SetActive(false);
        } else {
            ActionMenu.SetActive(true);
        }
    }

    public void Click_Bag_Button()
    {
        if (Inventory.activeSelf == true)
        {
            Inventory.SetActive(false);
        }
        else
        {
            Inventory.SetActive(true);
        }
    }

}
