using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Object_Guitar : MonoBehaviour
{
    public Transform playerTr;
    private Transform guitarTr;

    public AudioSource melody;
    public AudioClip mp3;

    // Start is called before the first frame update
    void Start()
    {
        guitarTr = GetComponent<Transform>();
        melody.clip = mp3;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(guitarTr.position, playerTr.position);
        if ((dist <= 10.0f) && (melody.isPlaying == false))
        {
            melody.Play();
            //Debug.Log("Play");
        }
        else if (dist > 10.0f)
            melody.Stop();
        
    }

    
}
