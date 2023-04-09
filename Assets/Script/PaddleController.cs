using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    //public float springPower;
    private float targerPressed;
    private float targetRealese;

    private HingeJoint hinge;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();

        targerPressed = hinge.limits.max;
        targetRealese    = hinge.limits.min;
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = hinge.spring;

        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targerPressed;
        }
        else
        {
            jointSpring.targetPosition = targetRealese;
        }

        hinge.spring = jointSpring;
    }
}