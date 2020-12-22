using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Louis_Teleport : MonoBehaviour
{
    public GameObject portal;
    public string destination;
    public GameObject Louis;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Louis)
            SceneManager.LoadScene(destination);//MoveGameObjectToScene(Louis, "Basic Scene");
    }
}
