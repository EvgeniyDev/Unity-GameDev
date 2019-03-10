using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System;
using UnityStandardAssets.CrossPlatformInput;


public class Items : MonoBehaviour
{
	public int[] items;
	public int mouseSlot;
	public ShopScript lib;
	public FirstPersonController fps;

	private bool invent = false;

	public Texture2D cursorTexture;

	void Start(){
		Cursor.lockState =  CursorLockMode.Locked;
		Cursor.visible = false;

		CursorMode cursorMode = CursorMode.Auto;
		Vector2 hotSpot = Vector2.zero;
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
		
	void Update(){
		if (Input.GetKeyDown(KeyCode.E))
		{
			invent = !invent;
			if (invent) {
				Time.timeScale = 0;
				Cursor.lockState =  CursorLockMode.None;
				Cursor.visible = true;

				fps.enabled = false;
			} else {
				Time.timeScale = 1;
				Cursor.lockState =  CursorLockMode.Locked;
				Cursor.visible = false;

				fps.enabled = true;
			}
		}
	}

	void OnGUI()
	{
		if (invent) {
			for (int x = 0; x < 5; x++) 
			{
				for (int y = 0; y < 5; y++)
				{
					if (GUI.Button (new Rect (x * 100, y * 100, 100, 100), lib.Images [items[y*5+x]])) {
						int loc = items [y * 5 + x];
						items [y * 5 + x] = mouseSlot;
						mouseSlot = loc;
					}
				}
			}
			GUI.DrawTexture (new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 100), lib.Images [mouseSlot]);
		}
	}
}
