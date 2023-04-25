using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class LeaveRoomOnInput : MonoBehaviour
{
    public InputHelpers.Button inputHelpers = InputHelpers.Button.MenuButton;
    public XRNode controller = XRNode.LeftHand;

    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), inputHelpers, out bool isPressed);

        if (isPressed)
        {
            PhotonNetwork.Disconnect();
            //PhotonNetwork.LoadLevel(0);
        }
    }


    public void ExitRoom()
    {
        PhotonNetwork.Disconnect();
        //PhotonNetwork.LoadLevel(0);
    }
}
