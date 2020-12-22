using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MinimapIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private MinimapToolTip theMinimapToolTip;
    [TextArea(1, 20)]
    public string iconName;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("entered");
        theMinimapToolTip.ShowToolTip(iconName, transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemDatabase.instance.HideToolTip();
    }
}
