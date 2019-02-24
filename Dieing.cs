using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Dieing : MonoBehaviour
{
	public static bool playgame;
	public int counts;
	public static int score;
	public GameObject obj;
	public GameObject texting;
	TextMesh show;
	int j=0;
	static string sai;
	Vector3 temp;
	SOME soo;
	bool showing;
	public void counter(int b)
	{
		counts = b;
	}
	void Start()
	{
		show = texting.GetComponent<TextMesh> ();
		soo = new SOME ();
	}
	public void message(int a)
	{
		
		sai = a.ToString ();


	}
	 void Update()
	{
		string some = counts.ToString ();
		show.text = some;
		temp = transform.position;
		if (temp.y <= 1f) 
		{
			//Debug.Log ("game over");
			//soo.GUI ();
			if (j == 0) {

				playgame = true;
				//StartCoroutine (stop());
				showing = true;
				j = 1;
			}
			//return;
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log ("saikumar");
		if (other.gameObject.tag == "same") 
		{
			counts--;
			Debug.Log ("counts :" + counts);
		}
		if (counts == 0) 
		{
			score++;
			Destroy (obj);
			counts = 0;
		}
	}
	void OnGUI()
	{
		if (showing) {
			GUI.BeginGroup (new Rect (1, 1, Screen.width,Screen.height));
			GUI.skin.label.fontSize = 30;
			GUI.contentColor = Color.white;
			GUI.skin.label.fontStyle = FontStyle.BoldAndItalic;
			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, 400, 100), "GAME OVER");
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2.3f, 100, 20), "Replay")) 
			{
				//SceneManager.UnloadSceneAsync (1);

				player.ss = 0;
				Bullets.material = 1;
				score = 0;

				playgame = false;
				showing = false;
				SceneManager.LoadScene (1);
				return;

				Debug.Log ("sai");
			}
			if (GUI.Button (new Rect (Screen.width / 2f, Screen.height / 2.3f, 100, 20), "Exit")) 
			{
				Application.Quit ();

			}
			GUI.EndGroup ();
		}


	}
	IEnumerator stop()
	{
		yield return new WaitForSeconds (1f);
	}

}
