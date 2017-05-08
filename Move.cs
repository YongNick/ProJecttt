using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public GameObject PlayerCharactor;
	private Rigidbody PCRig;
	public float MoveSpeed = 10.0f;
	// Use this for initialization
	void Start () {
		PCRig = PlayerCharactor.GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		if (GUI.RepeatButton (new Rect (10, 330, 100, 80), "Button!")) 
		{
			PlayerCharactor.gameObject.transform.Translate (new Vector3 (-MoveSpeed, 0, 0)*Time.deltaTime);
		}
		if (GUI.RepeatButton (new Rect (170, 330, 100, 80), "Button!")) 
		{
			PlayerCharactor.gameObject.transform.Translate (new Vector3 (MoveSpeed, 0, 0)*Time.deltaTime);
		}
		if (GUI.Button (new Rect (890, 330, 100, 80), "Jump!")) 
		{
			PCRig.AddForce (new Vector3 (0,10.0f,0)*100f);
		}
	}
}
