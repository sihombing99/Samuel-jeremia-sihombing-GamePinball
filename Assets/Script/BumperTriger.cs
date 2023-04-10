using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperTriger : MonoBehaviour
{
	public GameObject Ball;
	public float multiplier;
	public Material[] color;
	Renderer rend;
	Animator hit_anim;
	bool colorChangging= false;


	void Start()
	{
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		int i = Random.Range(0, 2);
		rend.sharedMaterial = color[i];
		hit_anim = GetComponent<Animator>();
	

	}
    private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Ball")
		{
			hit_anim.SetTrigger("Hittrigger");
			Rigidbody ballRig = Ball.GetComponent<Rigidbody>();
            ballRig.velocity *= multiplier;
            int i = Random.Range(1, 2);
			colorChangging = true;
            rend.sharedMaterial = color[i];
            
            Debug.Log("animasi");

		}
        else if (!colorChangging)
        {
			StartCoroutine(Colorback());
			//int i = Random.Range(0, 2);
			//rend.sharedMaterial = color[i];
			
		}
	}
	 IEnumerator Colorback()
    {
			yield return new WaitForSeconds(.1f);
			rend.sharedMaterial = color[0];
	
    }
}
