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
	public bool IsHit = false;
	private int hit_animation;

	void Start()
	{
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		int i = Random.Range(0, 1);
		rend.sharedMaterial = color[i];
		hit_anim = GetComponent<Animator>();
		hit_animation= Animator.StringToHash("animasipaddle");

	}
    private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider == Ball)
		{
			
			Rigidbody ballRig = Ball.GetComponent<Rigidbody>();
			ballRig.velocity *= multiplier;

			rend.sharedMaterial = color[0];
			IsHit = true;
			hit_anim.SetBool("animasipaddle", true);
				hit_anim.SetTrigger("Hittrigger");
				Debug.Log("animasi");

		}
        else
        {	
			rend.sharedMaterial = color[1];
			
		}
	}
	 IEnumerator Colorback()
    {
		if (rend.sharedMaterial = color[0])
        {
			yield return new WaitForSeconds(.1f);
			rend.sharedMaterial = color[1];
		}
    }
}
