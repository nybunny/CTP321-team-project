using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public float speed = 10.0f;
    public float minZoom = 10.0f;
    public float maxZoom = 40.0f;

    private float zoom;
    private Camera camera;

// Start is called before the first frame update
void Start()
    {
        zoom = 20.0f;
        camera = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float scroll =  Input.GetAxis("Mouse ScrollWheel") * speed;
        zoom -= scroll;
        if (scroll !=0 && minZoom < zoom && zoom < maxZoom)
        {
            camera.fieldOfView = zoom;
        }
        else
            zoom += scroll;
    }
}
