using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerZoomOut : MonoBehaviour
{
    public Collider bola;
    public CameraControl cameraController;
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            cameraController.GoBackToDefault();
        }
    }
}
