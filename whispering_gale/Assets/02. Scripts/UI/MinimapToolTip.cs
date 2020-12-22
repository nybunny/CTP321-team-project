using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapToolTip : MonoBehaviour
{
    [SerializeField]
    private GameObject Base;

    [SerializeField]
    private Text IconName;

    public void ShowToolTip(string name, Vector3 _pos)
    {
        Base.SetActive(true);
        _pos += new Vector3(-Base.GetComponent<RectTransform>().rect.width * 0.5f, 0.0f, 0.0f);
        Base.transform.position = _pos;

        IconName.text = name;
    }

    public void HideToolTip()
    {
        Base.SetActive(false);
    }
}
