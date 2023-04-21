using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //public Transform dummyTarget;
    //public float dummylenght;

    public float returnTime;
    public float followSpeed;
    public bool HasTarget { get { return target != null; } }
    public float lenght;

    private Vector3 defaultposition;
    public   Transform target;

    void Start()
    {
        defaultposition = transform.position;
        target = null;
    }
    private void Update()
    {
        if (HasTarget) { 
        Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
        Vector3 targetPosition = target.position + (targetToCameraDirection * lenght);

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }


        //    if (Input.GetKey(KeyCode.Tab))
        //    {
        //        FocusTarget(dummyTarget, 10f);
        //    }
        //    if (Input.GetKey(KeyCode.R))
        //    {
        //        GoBackToDefault();
        //    }
    }

    public void FollowTarget(Transform targetTransfrom, float targetLenght)
    {
        StopAllCoroutines();
        target = targetTransfrom;
        lenght = targetLenght;  
        
        //Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
        //Vector3 targetPosition = targetTransfrom.position + (targetToCameraDirection*lenght);

        //StartCoroutine(movePositon(targetPosition, 5));
    }

    public void GoBackToDefault()
    {
        target = null;
        StopAllCoroutines();
        StartCoroutine(movePositon(defaultposition, returnTime));
    }

    private IEnumerator movePositon(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;
        while (timer < time)
        {
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f,1.0f, timer/time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = target;
    }
}
