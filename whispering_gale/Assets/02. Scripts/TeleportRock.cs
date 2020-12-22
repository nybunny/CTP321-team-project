using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRock : MonoBehaviour
{
    public GameObject louis;
    public GameObject teleportNotice;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == louis)
        {
            teleportNotice.gameObject.SetActive(true);
        }
    }
}
