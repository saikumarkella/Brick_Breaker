using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_end : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Debug.Log ("end the game");
		}
	}
}
