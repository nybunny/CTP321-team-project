using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public List<Item> itemDB = new List<Item>();

    [SerializeField]
    private SlotToolTip theSlotToolTip;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        Inventory.instance.setDB(itemDB);
    }

    public void ShowToolTip(Item _item, Vector3 _pos)
    {
        theSlotToolTip.ShowToolTip(_item, _pos);
    }

    public void HideToolTip()
    {
        theSlotToolTip.HideToolTip();
    }

}
