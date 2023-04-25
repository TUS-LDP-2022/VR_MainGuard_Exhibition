using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using Photon.Pun;

public class XRGrabNetworkInteractable : XRGrabInteractable
{


    PhotonView photonView;
    Rigidbody rigidbodyObj;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        rigidbodyObj = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*  
    protected override void OnSelectEntered(XRBaseInteractor interactor)   //not going to work? deprecated
    {
        base.OnSelectEntered(interactor);

       
    }
    */


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        photonView.RequestOwnership();
        base.OnSelectEntered(args);
        //trying to sync objects positions for both players
        rigidbodyObj.isKinematic = true;
        rigidbodyObj.detectCollisions = false;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        //trying to sync objects positions for both players
        rigidbodyObj.isKinematic = false;
        rigidbodyObj.detectCollisions = true;
    }

}
