using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerZoomIn : MonoBehaviour
{
    public Collider bola;
    public CameraControl cameraController;
    public float leght;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            cameraController.FollowTarget(bola.transform, leght);
        }
    }
}
