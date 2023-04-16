using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncerControler : MonoBehaviour
{
    public Collider ball;
    public KeyCode input;
   // public float force;

    public float maxTimeHold;
    public float maxForce;

    private Renderer render;
    private bool isHold;
    public Material colorHold;
    public Material colorNotHold;
    public Material colorMaxHold;

    private void Start()
    {
        isHold = false;
        render= GetComponent<Renderer>();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == ball)
        {
            ReadInput(ball);
        }
        Debug.Log("stay");
        
    }
    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input)&&!isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0f;
        float timeHold = 0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
            
            if (timeHold < maxTimeHold)
            {
                render.material = colorHold;
            }
            else if(timeHold > maxTimeHold)
            {
                render.material = colorMaxHold;
            }
        }

            collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        render.material = colorNotHold;

    }
}

