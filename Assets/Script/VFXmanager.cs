using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXmanager : MonoBehaviour
{
    public GameObject VFX;
    public void PlayVFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(VFX, spawnPosition, Quaternion.identity);
    }

}
