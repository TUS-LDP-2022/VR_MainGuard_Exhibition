using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffMainGuardExterior : MonoBehaviour
{
    public GameObject MGExterior;
    public GameObject _player;

    private void Start()
    {
        MGExterior.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            MGExterior.SetActive(false);
            Debug.Log("Turning off");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            MGExterior.SetActive(true);
            Debug.Log("Turning on");
        }
    }
}
