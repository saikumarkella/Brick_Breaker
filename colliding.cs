 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliding : MonoBehaviour
{
	CircleCollider2D cool;
	void Start()
	{
		
	}
	void Update()
	{
		
	}
	void OnCollisionEnter2D(Collision2D collider)
	{
		Debug.Log ("saikumar");

		if (collider.gameObject.tag == "same") {
			cool = collider.gameObject.GetComponent<CircleCollider2D> ();
			cool.isTrigger = true;
			StartCoroutine (cooo(cool));


		}

	}
	IEnumerator cooo(CircleCollider2D can)
	{
		Debug.Log ("kumar");
		yield return new WaitForSeconds (0.005f);
		can.isTrigger = false;

	}


}
