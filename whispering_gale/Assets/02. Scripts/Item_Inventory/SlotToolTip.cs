using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotToolTip : MonoBehaviour
{
    [SerializeField]
    private GameObject Base;

    [SerializeField]
    private Text ItemName;
    [SerializeField]
    private Text ItemDesc;

    public void ShowToolTip(Item _item, Vector3 _pos)
    {
        Base.SetActive(true);
        _pos += new Vector3 (-Base.GetComponent<RectTransform>().rect.width * 0.5f, 0.0f, 0.0f);

        Base.transform.position = _pos;

        ItemName.text = _item.itemName;
        ItemDesc.text = _item.itemDescribe;
    }

    public void HideToolTip()
    {
        Base.SetActive(false);
    }
}
