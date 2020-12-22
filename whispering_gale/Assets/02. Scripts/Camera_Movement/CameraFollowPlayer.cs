using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    //public float speedH = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    /* 만약 카메라가 흔들리면, player가 일정 범위 이하만 움직일 때는 카메라 움직이지 않도록 조정
    (Cinemachine이 지원하지 않는 것 같아서 카메라에다가 직접 스크립트 추가함) */

    // LateUpdate is called after Update methods
    void LateUpdate()
    {
        // Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X) * speedH, Vector3.up);
        //_cameraOffset = camTurnAngle * _cameraOffset; //rotate camera around player (ver1)
        transform.Rotate(Vector3.up, Input.mouseScrollDelta.y);
        //transform.rotation = camTurnAngle;

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
    }
}
