using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSaveData : MonoBehaviour
{
    public string player_name;

    private int file_number;
    private bool newFile;

    /*
     <List of keys used in all files>
     highest_fnum // highest file number
     */

    /*
    <List of keys for individual save files>
    player_name --> its key is file_number
    (file_number)_tutorial_house
    (file_number)_tutorial_walk
    (file_number)_tutorial_run
    (file_number)_tutorial_food
    
    (file_number)_quest11 (Grandpa's time capsule)
    (file_number)_quest12
    (file_number)_quest13
    (file_number)_quest14 (Grandma's time capsule)
    (file_number)_quest15
    (file_number)_quest16 (hidden quest)
    (file_number)_quest17 (Louis's time capsule; final quest)

    ex) player_name = "ctp321", file_number = 0 --> then keys are: 0_tutorial_house, 0_quest11, ...

    For file_number, the value is an int.
    For all keys excluding file_number:
        value = 0(not started), 1(hasStarted), 2(completed)
        if the key doesn't exist, count as not started

    */

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll(); // delete this line before building

        if (PlayerPrefs.HasKey(player_name))
        {
            Debug.Log("existing save file");
            file_number = PlayerPrefs.GetInt(player_name);
            newFile = false;
        }
        else
        {
            Debug.Log("new file");
            if (PlayerPrefs.HasKey("highest_fnum"))
            {
                file_number = PlayerPrefs.GetInt("highest_fnum") + 1;
            }
            else
            {
                file_number = 0;
                PlayerPrefs.SetInt("highest_fnum", 0);
            }
            //Debug.Log(PlayerPrefs.GetInt(player_name));
            //Debug.Log(PlayerPrefs.GetInt("highest_fnum"));

            PlayerPrefs.SetInt(player_name, file_number);
            newFile = true;
            // delete previous data with the same file_number!
        }

    }

    public void SaveInventorySize(int size)
    {
        PlayerPrefs.SetInt("Inventory", size);
    }

    public void SaveItem(int pos, int itemNum)
    {
        PlayerPrefs.SetInt("Inventory" + pos.ToString(), itemNum);
    }
    
    public List<int> LoadInventory()
    {
        List<int> items = new List<int>();
        int size = PlayerPrefs.GetInt("Inventory");
        for (int i = 0; i < size; i++)
        {
            items.Add(PlayerPrefs.GetInt("Inventory" + i.ToString()));
        }
        return items;
    }

    public void SaveQuestStarted(int questNum)
    {
        if (questNum > 10) //story quest
            PlayerPrefs.SetInt(file_number.ToString() + "_quest" + questNum.ToString(), 1);
        else //tutorial quest
        {
            if (questNum == 1) //walk tutorial
            {
                PlayerPrefs.SetInt(file_number.ToString() + "_tutorial_walk", 1);
            }
            else if (questNum == 2) //run tutorial
            {
                PlayerPrefs.SetInt(file_number.ToString() + "_tutorial_run", 1);
                Debug.Log("Run tutorial:");
                Debug.Log(PlayerPrefs.GetInt(file_number.ToString() + "_tutorial_run"));
                Debug.Log("Walk tutorial:");
                Debug.Log(PlayerPrefs.GetInt(file_number.ToString() + "_tutorial_walk"));
            }
            else if (questNum == 3) //house tutorial
            {
                PlayerPrefs.SetInt(file_number.ToString() + "_tutorial_house", 1);
            }
            else if (questNum == 4)
            {
                PlayerPrefs.SetInt(file_number.ToString() + "_tutorial_food", 1);
            }
        }
    }

    public void SaveQuestCompleted(int questNum)
    {
        if (questNum > 10) //story quest
            PlayerPrefs.SetInt(file_number.ToString() + "_quest" + questNum.ToString(), 2);
        else //tutorial quest
        {
            if (questNum == 1) //walk tutorial
            {
                PlayerPrefs.SetInt(file_number.ToString() + "_tutorial_walk", 2);
            }
            else if (questNum == 2) //run tutorial
            {
                PlayerPrefs.SetInt(file_number.ToString() + "_tutorial_run", 2);
                Debug.Log("Run tutorial:");
                Debug.Log(PlayerPrefs.GetInt(file_number.ToString() + "_tutorial_run"));
                Debug.Log("Walk tutorial:");
                Debug.Log(PlayerPrefs.GetInt(file_number.ToString() + "_tutorial_walk"));
            }
            else if (questNum == 3) //house tutorial
            {
                PlayerPrefs.SetInt(file_number.ToString() + "_tutorial_house", 2);
            }
            else if (questNum == 4)
            {
                PlayerPrefs.SetInt(file_number.ToString() + "_tutorial_food", 2);
            }
        }
    }

    public int[] GetStoryData(int fileNumber)
    {
        int quest11 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest11");
        int quest12 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest12");
        int quest13 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest13");
        int quest14 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest14");
        int quest15 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest15");
        int quest16 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest16");
        int quest17 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest17");

        return new int[] { quest11, quest12, quest13, quest14, quest15, quest16, quest17 };
    }

    public int[] GetTutorialData(int fileNumber)
    {
        int tutorial_house = PlayerPrefs.GetInt(fileNumber.ToString() + "_tutorial_house");
        int tutorial_walk = PlayerPrefs.GetInt(fileNumber.ToString() + "_tutorial_walk");
        int tutorial_run = PlayerPrefs.GetInt(fileNumber.ToString() + "_tutorial_run");

        return new int[] { tutorial_house, tutorial_walk, tutorial_run };
    }
}

