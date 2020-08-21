using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyDetected : MonoBehaviour
{
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            audio.Play(); 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            audio.Stop();
    }
}
