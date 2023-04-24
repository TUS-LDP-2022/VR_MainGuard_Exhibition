using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuilding : MonoBehaviour
{
    public GameObject Reception;
    public GameObject Mainguard;
    public GameObject TopFloor;
    public GameObject Player;
    public GameObject DesiredPosition = null;
    public GameObject TP = null;
    public GameObject blackout;
    public Animator Animation;

    private void Start()
    {
        blackout.SetActive(false);
    }
    public void MovePlayer()
    {
        StartCoroutine(MoveP());
        blackout.SetActive(true);
        Animation.SetBool("start", true);
    }

    IEnumerator MoveP()
    {
        yield return new WaitForSeconds(2);
        Player.transform.position = DesiredPosition.transform.position;
        Player.transform.rotation = DesiredPosition.transform.rotation;
        Animation.SetBool("start", false);
    }
    
    public void TurnOnTP()
    {
        TP.SetActive(true);
    }
    public void TurnOffTP()
    {
        TP.SetActive(false);
    }
    public void TurnOnMG()
    {
        Mainguard.SetActive(true);
    }

    public void TurnOnReception()
    {
        Reception.SetActive(true);
    }

    public void TurnOnTopFloor()
    {
        TopFloor.SetActive(true);
    }

    public void TurnOffMG()
    {
        Mainguard.SetActive(false);
    }

    public void TurnOffReception()
    {
        Reception.SetActive(false);
    }

    public void TurnOffTopFloor()
    {
        TopFloor.SetActive(false);
    }
}
