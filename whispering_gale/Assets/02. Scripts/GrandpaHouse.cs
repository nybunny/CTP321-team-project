using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandpaHouse : MonoBehaviour
{
 //   private Scene house;
    // Start is called before the first frame update
    void Start()
    {
   //     house = SceneManager.GetSceneByName("GrandpaHouse"); //index = 5
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("GrandpaHouse");
    }
}
