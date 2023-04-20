using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTitleToPicture : MonoBehaviour
{
    [SerializeField] private GameObject story;
    [SerializeField] private AudioSource plaque;

    public void DisplayText()
    {
        story.SetActive(true);
        plaque.Play();
    }

    public void HideText()
    {
        story.SetActive(false);
        plaque.Stop();
    }
}
