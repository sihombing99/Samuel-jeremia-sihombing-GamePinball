using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGM;
    public GameObject SFX;
    void Start()
    {
        PlayBGM();
    }

    // Update is called once per frame
    public void PlayBGM()
    {
        
    }
    public void PlaySFX(Vector3 SpawnPosition)
    {
        GameObject.Instantiate(SFX, SpawnPosition, Quaternion.identity);
    }
}
