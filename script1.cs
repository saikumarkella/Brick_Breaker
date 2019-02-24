using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class script1 : MonoBehaviour
{
	public void Quit()
	{
		Application.Quit ();
	}
	public void Play()
	{
		SceneManager.LoadScene (1);
	}
	
}
