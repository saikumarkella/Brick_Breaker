using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public static Vector3 shooter_pos;
	public GameObject aimii;
	[HideInInspector]
	public static int mm=1;
	[SerializeField]
	private GameObject bullet;
	[SerializeField]
	private float[,] value;
	float speed;
	[SerializeField]
	private float power=1000f;
	public GameObject obj;
	GameObject tar,blockclone;
	Rigidbody2D body;
	Coroutine rout;
	ConstantForce2D force;
	[SerializeField]
	private GameObject block;
	Vector2 aiming;
	Vector3 angle;
	float s,c;
	GameObject[] objects;
	Transform form;
	killing kill;
	bool cond=true;
	public int kk{ set; get; }
	Dieing die;
	GameObject[] circles;
	public static int ss;
	Vector3 temp1;
	Vector3 temp2;
	Bullets bot;
	void Start()
	{
		shooter_pos = transform.position;
		form = GetComponent<Transform> ();
		bot = new Bullets ();
		kill = new killing ();
		value = new float[5, 7];
		value [0, 0] = -4.87f;
		value [0, 1] = -3.31f;
		value [0, 2] = -1.93f;
		value [0, 3] = -0.26f;
		value [0, 4] = 1.12f;
		value [0, 5] = 2.74f;
		value [0, 6] = 4.35f;
		value [1, 0] = -4.91f;
		value [1, 1] = -3.65f;
		value [1, 2] = 0f;
		value [1, 3] = -2.07f;
		value [1, 4] = 1.92f;
		value [1, 5] = 3.47f;
		value [1, 6] = 4.82f;
		value [2, 0] = -4.43f;
		value [2, 1] = -3.08f;
		value [2, 2] = -1.64f;
		value [2, 3] = -0.14f;
		value [2, 4] = 1.47f;
		value [2, 5] = 3.05f;
		value [2, 6] = 4.61f;
		value [3, 0] = -3.76f;
		value [3, 1] = -2.23f;
		value [3, 2] = -0.62f;
		value [3, 3] = 0.99f;
		value [3, 4] = 2.22f;
		value [3, 5] = 3.6f;
		value [3, 6] = 4.89f;
		value [4, 0] = -4.14f;
		value [4, 1] = -2.7f;
		value [4, 2] = -1.6f;
		value [4, 3] = 0.41f;
		value [4, 4] = 2.02f;
		value [4, 5] = 3.37f;
		value [4, 6] = 4.72f;
	}
	void Update()
	{
		shooter_pos.x = killing.Ppp ();
		aimii.transform.position = shooter_pos;
		bool some = kill.reseve ();
		//Debug.Log ("sadad :" + some);
		angle = transform.eulerAngles;
		if (kill.something()==0 && !Dieing.playgame )
		{
			
			aimii.SetActive (true);
			if(some&&cond) 
			{
				
				StartCoroutine (building ());
				objects = GameObject.FindGameObjectsWithTag ("Player");
				circles = GameObject.FindGameObjectsWithTag ("circle");
				for (int i = 0; i < objects.Length; i++) {
					Vector2 temp = objects [i].transform.position;
					temp.y -= 1.5f;
					objects [i].transform.position = temp;
				}
				for (int i = 0; i < circles.Length; i++) {
					Vector2 temp = circles [i].transform.position;
					temp.y -= 1.5f;
					circles [i].transform.position = temp;
				}
				cond = false;
			} 
		
			if (Input.GetKey(KeyCode.A)) {
				
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.left), 1f * Time.deltaTime);
				 temp1 = transform.eulerAngles;
				 temp2 = aimii.transform.eulerAngles;
			}
			if (Input.GetKey(KeyCode.D)) {
				
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.right), 1f * Time.deltaTime);
				 temp1 = transform.eulerAngles;
				 temp2 = aimii.transform.eulerAngles;

			}
			aimii.transform.rotation = Quaternion.Euler (temp2.x, temp2.y, -temp1.y);



			if (Input.GetKeyDown (KeyCode.Space)) {
				angle = transform.eulerAngles;
				s = Mathf.Sin ((angle.y + 270f) * Mathf.Deg2Rad);
				c = Mathf.Cos ((angle.y + 270f) * Mathf.Deg2Rad);
				StartCoroutine (waiting (s, c));
		
			}

				


		}

	}
	IEnumerator waiting(float k,float m )
	{
		aimii.SetActive (false);
		mm = Bullets.material;
		transform.position = shooter_pos;
		kill.balls (mm);
		for(int i=0;i<mm;i++)
		{
			
			tar = Instantiate (obj, transform.position, Quaternion.Euler(0,0,0));

			speed = 1f * Time.deltaTime;
			body = tar.GetComponent<Rigidbody2D> ();

			body.mass=Mathf.Sqrt((k*k)+(m*m));

			k = Mathf.Abs (k);
			body.AddForce (new Vector2 (m,k) * power);


			yield return new WaitForSeconds (0.03f);

		}
		cond = true;



	}
	IEnumerator building()
	{
		
		ss++;
		int m=1 ;
		if (ss <= 25) {
			//Debug.Log ("leavel 1");
			m = Random.Range (1, 6);
		}
		else if(ss>=26&&ss<80) 
		{
			m = Random.Range (4, 7);
		}
		else
		{
			m=Random.Range(4,9);
		}

		GameObject[] blockss=new GameObject[m];
		int[] kk = new int[m];
		GameObject  g;
		Dieing die;
		TextMesh textt;
		int b = Random.Range (0, 4);
		for (int i = 0; i < m; i++) {
			int a = Random.Range (0, 6);
			kk [i] = a;
			blockss[i]=Instantiate (block, new Vector2 (value [b,a], 15f), Quaternion.Euler (0, 0, 45f));
			textt = (TextMesh)blockss [i].GetComponentInChildren<TextMesh> ();
			textt.text = ss.ToString ();
			die = (Dieing)blockss [i].GetComponentInChildren<Dieing>();
			die.counts = ss;

		}
		if (m < 6) 
		{
			int n = 6 - m;
			int l = 0;
			if (ss > 80) 
			{
				l = Random.Range (1, 4);
			}
			else{
				l = Random.Range (0, 3);
			}
			int c = 0;
			float[] a = new float[n];
			for (int i = 0; i < n; i++) 
			{
				for (int j = 0; j < m; j++) 
				{
					if (c != kk [j])
						break;
					else 
					{
						c++;
					}
				}
				a [i] = value [b,c];
				c++;

			}
			for (int i = 0; i <l; i++) 
			{
				Instantiate (bullet, new Vector2 (a [Random.Range (0, n)], 15f), Quaternion.identity);
			}
		}
		yield return new WaitForSeconds (0.1f);
	}
	void OnGUI()
	{
		GUI.BeginGroup (new Rect (1, 1, Screen.width, Screen.height));
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 15;
		GUI.Label (new Rect (Screen.width/1.7f,(Screen.height/2)*(3.4f/2), 200, 400), "Balls :"+Bullets.material);
		GUI.EndGroup ();
	}




}
