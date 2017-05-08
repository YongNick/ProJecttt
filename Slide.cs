using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour {
	public Button Left;
	public Button Center;
	public Button Right;
	public Button[] Buttons;
	bool isFirst;
	bool isChange;
	float LeftX;
	float RightX;
	float CenterX;
	float CenterY;
	float PosX;
	float PosY;
	// Use this for initialization
	void Start () 
	{
		isFirst = true;
		isChange = true;
		CenterX = Center.transform.position.x;
		CenterY = Center.transform.position.y;
		LeftX = Left.transform.position.x;
		RightX = Right.transform.position.x;
	}

	// Update is called once per frame
	void Update ()
	{
		if (isFirst) {
			if (Input.GetMouseButton (0)) 
			{
				if (Input.mousePosition.x >= CenterX-4.0f && Input.mousePosition.x <= CenterX + 160.0f
					&& Input.mousePosition.y <= 70 && Input.mousePosition.y >= 10.0f) 
				{
					PosX = Input.mousePosition.x;
					PosY = Input.mousePosition.y;
					isFirst = false;
				}
			}
			else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
			{
				if (Input.mousePosition.x >= CenterX && Input.mousePosition.x <= CenterX + 160.0f
					&& Input.mousePosition.y <= 70 && Input.mousePosition.y >= 10.0f) 
				{
					PosX = Input.GetTouch(0).position.x;
					PosY = Input.GetTouch(0).position.y;
					isFirst = false;
				}
			}
		}
		else 
		{
			if (isChange) 
			{
				
				if (Input.touchCount > 0 &&Input.GetTouch(0).phase == TouchPhase.Moved) 
				{
					if (PosX > Input.mousePosition.x + 30.0f) 
					{
						Button TempButton;
						TempButton = Buttons [0];
						Buttons [0] = Buttons [1];
						Buttons [1] = Buttons [2];
						Buttons [2] = TempButton;
						isChange = false;
					} 
					else if (PosX < Input.mousePosition.x - 30.0f) 
					{
						Button TempButton;
						TempButton = Buttons [2];
						Buttons [2] = Buttons [1];
						Buttons [1] = Buttons [0];
						Buttons [0] = TempButton;
						isChange = false;
					}
				}
				if (Input.GetMouseButton(0)) 
				{
					if (PosX > Input.mousePosition.x + 30.0f) 
					{
						Button TempButton;
						TempButton = Buttons [0];
						Buttons [0] = Buttons [1];
						Buttons [1] = Buttons [2];
						Buttons [2] = TempButton;
						isChange = false;
					} 
					else if (PosX < Input.mousePosition.x - 30.0f) 
					{
						Button TempButton;
						TempButton = Buttons [2];
						Buttons [2] = Buttons [1];
						Buttons [1] = Buttons [0];
						Buttons [0] = TempButton;
						isChange = false;
					}
				}
			}
		}
		if (Input.GetMouseButtonUp(0)) 
		{
			isChange = true;	
			isFirst = true;
			Buttons [0].transform.position = new Vector3 (LeftX, 37.0f, 0);
			Buttons [0].interactable = false;
			Buttons [1].transform.position = new Vector3 (CenterX, 37.0f, 0);
			Buttons [1].interactable = true;
			Buttons [2].transform.position = new Vector3 (RightX, 37.0f, 0);
			Buttons [2].interactable = false;
		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) 
		{
			isChange = true;	
			isFirst = true;
			Buttons [0].transform.position = new Vector3 (LeftX, 37.0f, 0);
			Buttons [0].interactable = false;
			Buttons [1].transform.position = new Vector3 (CenterX, 37.0f, 0);
			Buttons [1].interactable = true;
			Buttons [2].transform.position = new Vector3 (RightX, 37.0f, 0);
			Buttons [2].interactable = false;
		}
	}
}
