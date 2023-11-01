using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System.Collections;

using Photon.Pun;

public class PlaceTextTest : MonoBehaviourPunCallbacks //, IPunObservable
{
    private ARRaycastManager arRaycastManager;
    private ARSessionOrigin arOrigin;
    private ARAnchorManager anchorManager;
    private ARPlaneManager arPlaneManager = null;

    bool firstPlaneDetected = false;

    public TMPro.TextMeshProUGUI debugText;
    public float distanceInFrontOfCamera = 0.5f;

    [SerializeField] private GameObject canvasObjectPrefab;
    private Image text_image;


    void Start()
    {
        arOrigin = GetComponent<ARSessionOrigin>(); // get the ARSessionOrigin component
        anchorManager = GetComponent<ARAnchorManager>();
    }


    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlanesChanged;
    }

    private void PlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (!firstPlaneDetected && args.added != null && args.added.Count > 0)
        {
            // debugText.text = "Active";
            debugText.text = "";
            firstPlaneDetected = true;
        }
    }
    
    public void CreateCanvas()
    {
        Vector3 airPos = arOrigin.camera.transform.position + arOrigin.camera.transform.forward * distanceInFrontOfCamera;
        Quaternion airQua = Quaternion.LookRotation(-arOrigin.camera.transform.forward, arOrigin.camera.transform.up);

        var canvasObj = PhotonNetwork.Instantiate(canvasObjectPrefab.name, airPos, airQua);
        if (canvasObj == null)
        {
            Debug.Log("canvasObj is null");
        }
    }
    
}
