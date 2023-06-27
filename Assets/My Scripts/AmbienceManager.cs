using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    public AudioSource audioSource;
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "_player" && audioSource.isPlaying)
        {
            audioSource.Stop();
            Destroy(gameObject);
        }
    }
}
