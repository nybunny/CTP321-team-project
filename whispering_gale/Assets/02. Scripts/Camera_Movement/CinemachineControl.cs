using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float minZoom;
    public float maxZoom;

    private float zoom;
    private CinemachineVirtualCamera vcam;

// Start is called before the first frame update
void Start()
    {
        vcam = this.gameObject.GetComponent<CinemachineVirtualCamera>();
        zoom = vcam.m_Lens.FieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll =  Input.GetAxis("Mouse ScrollWheel") * speed;
        zoom -= scroll;
       // Debug.Log(scroll);
        if (scroll !=0 && minZoom < zoom && zoom < maxZoom)
        {
            vcam.m_Lens.FieldOfView = zoom;
        }
        else
            zoom += scroll;
    }
}
