using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTitleToPicture : MonoBehaviour
{
    [SerializeField] private GameObject story;
    [SerializeField] private GameObject plaque;

    public void DisplayText()
    {
        story.SetActive(true);
    }

    public void HideText()
    {
        story.SetActive(false);
    }
}
