using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    enum switchstate
    {
        Off,
        On,
        Blink,
    }
    //public GameObject ball;
    public Material switchcoloron;
    public Material switchcoloroff;
    switchstate state;
    //bool IsOn;
    Renderer renderWarna;
    void Start()
    {
        renderWarna = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinktimerStart(3));
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball"){
            Toggle();
            Debug.Log("gantiwarna");
        }
    }

    void Set(bool active)
    {
        if (active == true)
        {
            state = switchstate.On;
            renderWarna.material = switchcoloron;
            StopAllCoroutines();
        }
        else
        {
            state = switchstate.Off;
            renderWarna.material = switchcoloroff;
            StartCoroutine(BlinktimerStart(3));
        }

    }

    void Toggle()
    {
        if (state == switchstate.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }
    IEnumerator blink(int times)
    {
        state = switchstate.Blink;
        
        for(int i=0; i<times; i++)
        {
            state = switchstate.On;
            yield return new WaitForSeconds(0.2f);
            state = switchstate.Off;
            yield return new WaitForSeconds(0.2f);
        }
        state = switchstate.Off;
        StartCoroutine(BlinktimerStart(3));
    }
    IEnumerator BlinktimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(blink(2));
    }
}

