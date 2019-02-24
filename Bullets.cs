using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour 
{
	public static int material=1;
	Rigidbody2D body;
	GameObject part;
	public GameObject obj;
	void Start()
	{
		body = GetComponent<Rigidbody2D> ();
	}
	void Update()
	{
		
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		
		if (collider.gameObject.tag =="same2") 
		{
			//Debug.Log ("kumarrrrr");
			body.gravityScale = 3f;
			material++;
		    part =Instantiate (obj, transform.position, Quaternion.identity);
			Destroy (gameObject);
			StartCoroutine (particals ());
			//destroy ();
		}
		
	}
	IEnumerator particals()
	{
		//Destroy (part.gameObject);
		yield return new WaitForSeconds (1f);
		destroy ();
	}
	void destroy ()
	{
		//StartCoroutine (particals ());
		Destroy (part.gameObject);

	}

}
