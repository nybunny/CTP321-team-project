using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Slot[] slots;
    public Transform slotHolder;
    public List<Item> items = new List<Item>();
    public static Inventory instance;

    public GameObject menu;
    public QuestSaveData SaveData;

    private List<Item> database;

    void Awake()
    {
        instance = this;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        for (int i = 0; i < 20; i++)
        {
            slots[i].slotnum = i;
        }
    }

    void Start()
    {
        //AddItem(2); // Add Compass
        items.Clear();
        List<int> temp = SaveData.LoadInventory();
        foreach (int index in temp)
        {
            AddItem(index);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menu.GetComponent<Louis_Menu>().Click_Bag_Button();
        }
    }

    public void setDB(List<Item> DB)
    {
        database = DB;
    }

    public bool AddItem(int index)
    {
        Item item = database[index];

        if(items.Count < 20)
        {
            items.Add(item);
            slots[items.Count - 1].UpdateSlot(item);
            SaveData.SaveInventorySize(items.Count);
            SaveData.SaveItem(items.Count-1, index);
            return true;
        }
        return false;
    }

    public void RemoveItem(int slotnum)
    {
        int i = slotnum;
        items.Remove(slots[i].item);
        for (i = slotnum; i < items.Count; i++)
        {
            slots[i].UpdateSlot(slots[i+1].item);
            SaveData.SaveItem(i, slots[i+1].item.index);
        }
        slots[i].RemoveSlot();
        SaveData.SaveInventorySize(items.Count);
    }
    
}
