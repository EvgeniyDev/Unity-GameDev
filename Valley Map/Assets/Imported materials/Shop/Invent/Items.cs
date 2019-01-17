using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Items : MonoBehaviour
{
	public int[] items;
	public int mouseSlot;
	public ShopScript lib;


	private bool invent = false;



	void Update(){
		if (Input.GetKeyDown(KeyCode.E))
		{
			invent = !invent;
			Time.timeScale = 1;
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
