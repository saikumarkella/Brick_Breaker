using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
	private int a;
	private int m;
	bool showing;
	void Start()
	{
		
	}
	void Update()
	{
		a = Dieing.score;
		m = player.ss;
	}
	void OnGUI()
	{
		GUI.BeginGroup (new Rect(0,0,Screen.width,Screen.height));
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 15;
		GUI.skin.label.fontStyle = FontStyle.Italic;
		GUI.Label (new Rect (Screen.width/2.7f,Screen.height/12, 150, 100), "Distroy :"+a);
		GUI.Label (new Rect (Screen.width/1.7f,Screen.height/12, 200, 400), "Score :"+m);
		if (GUI.Button (new Rect (Screen.width / 2.15f, Screen.height / 12, 100, 20),"PAUSE")) 
		{
			//Debug.Log ("enter teh ");
			Dieing.playgame = true;
			showing = true;
		}
		GUI.EndGroup ();
		if (showing) {
			GUI.BeginGroup (new Rect (1, 1, Screen.width, Screen.height));
			GUI.skin.label.fontSize = 30;
			GUI.contentColor = Color.white;
			GUI.skin.label.fontStyle = FontStyle.BoldAndItalic;
			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, 400, 100), "GAME PAUSED");
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2.3f, 100, 20), "Resume")) 
			{
				showing = false;
				//player.ss = 0;
				Dieing.playgame = false;

			}
			if (GUI.Button (new Rect (Screen.width / 2f, Screen.height / 2.3f, 100, 20), "Abort")) 
			{
				Application.Quit ();
				//Debug.Log ("bye");
			}
			GUI.EndGroup ();
		}

	}

}
