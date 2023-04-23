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

    public void MovePlayer()
    {
        StartCoroutine(MoveP());
    }

    IEnumerator MoveP()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        Player.transform.position = DesiredPosition.transform.position;
        Player.transform.rotation = DesiredPosition.transform.rotation;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
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
