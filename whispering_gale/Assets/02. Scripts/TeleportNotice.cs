using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportNotice : MonoBehaviour
{
    private string currentScene;
    private GameObject teleportNotice;
    private GameObject[] teleportNoticeChildren;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        teleportNotice = GameObject.Find("TeleportNotice");
        DisableOwnSceneOption(currentScene);
    }

    private void DisableOwnSceneOption(string sceneName)
    {
        int n = teleportNotice.transform.childCount;
        teleportNoticeChildren = new GameObject[n - 1];
        for (int i = 1; i < n; i++)
        {
            teleportNoticeChildren[i - 1] = teleportNotice.transform.GetChild(i).gameObject;
        }

        foreach (GameObject child in teleportNoticeChildren)
        {
            child.SetActive(true);
        }

        if (sceneName == "GrandpaHouse")
            teleportNotice.transform.GetChild(3).gameObject.SetActive(false);
        else if (sceneName == "Graveyard")
            teleportNotice.transform.GetChild(4).gameObject.SetActive(false);
        else if (sceneName == "Temple")
            teleportNotice.transform.GetChild(5).gameObject.SetActive(false);
        else if (sceneName == "TownHouses")
            teleportNotice.transform.GetChild(6).gameObject.SetActive(false);
        else if (sceneName == "Midground")
            teleportNotice.transform.GetChild(7).gameObject.SetActive(false);
        else if (sceneName == "School")
            teleportNotice.transform.GetChild(8).gameObject.SetActive(false);
    }

    public void ToHouse()
    {
        //Debug.Log("to house");
        SceneManager.LoadScene("GrandpaHouse");
    }

    public void ToGraveyard()
    {
        SceneManager.LoadScene("Graveyard");
    }

    public void ToTemple()
    {
        SceneManager.LoadScene("Temple");
    }

    public void ToTownhouses()
    {
        SceneManager.LoadScene("TownHouses");
    }

    public void ToMidground()
    {
        SceneManager.LoadScene("Midground");
    }

    public void ToSchool()
    {
        SceneManager.LoadScene("School");
    }

    public void NeverMind()
    {
        Debug.Log("never mind");
        this.gameObject.SetActive(false);
    }
}
