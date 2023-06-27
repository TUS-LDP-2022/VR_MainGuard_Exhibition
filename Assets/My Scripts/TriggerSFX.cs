using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    public AudioSource audioSource;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "_player" && !audioSource.isPlaying)
        {
            audioSource.Play();
            Destroy(gameObject);
        }
    }
}
