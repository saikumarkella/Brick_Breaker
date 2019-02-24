using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killing : MonoBehaviour
{
	[HideInInspector]
	public static int count=0;
	public int man;
	player play;
	public GameObject game;
	Vector3 pos;
	static float p;
	public static bool varify=true;
	public bool reseve()
	{
		return varify;
	}
	public void balls(int a)
	{
		count = a;
	}
	void Start()
	{
		man = count;
		play = new player ();
	}

	void Update()
	{
		
		bool s = reseve ();
		int a=something ();
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		//killing o = new killing ();
		if (other.gameObject.tag =="same3") 
		{
			Debug.Log ("game over");
			
		}
		Destroy (other.gameObject);
		count--;

		if (count == 0) 
		{
			pos = other.transform.position;
			p = pos.x;
			if (p > 5.03f || p < -5.23f) 
			{
				p = 0;
			}
			varify = true;
		}
		else 
		{
			varify = false;
		}
		//Debug.Log (count);
	}
	public int something()
	{
		
		return count;
	}
	public static float Ppp()
	{
		return p;
	}

	


}
