using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperTriger : MonoBehaviour
{
	public GameObject Ball;
	public float multiplier;
	public Material color1;
	public Material color2;
	public Material color3;
	Renderer rend;
	Animator hit_anim;
	bool colorChangging;


	void Start()
	{
		rend = GetComponent<Renderer>();
		hit_anim = GetComponent<Animator>();
		setColor(colorChangging);
	

	}
    private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Ball")
		{
			hit_anim.SetTrigger("Hittrigger");
			Rigidbody ballRig = Ball.GetComponent<Rigidbody>();
            ballRig.velocity *= multiplier;

			setColor(!colorChangging);
            Debug.Log("animasi");
		}
		StartCoroutine(OtherColor());
	}
	void setColor(bool isActive)
    {
		colorChangging = isActive;
		if (colorChangging == true)
        {
			rend.material = color1; 
        }
        else
        {
			rend.material = color2;
        }
    }
	IEnumerator OtherColor()
    {
		yield return new WaitForSeconds(3f);
		rend.material = color3;
    }
}
