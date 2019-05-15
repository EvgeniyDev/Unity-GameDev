using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestOpenScript : MonoBehaviour
{
	public GameObject chestDoor;
	public AudioSource audioOpen;
	public AudioSource audioClose;

	protected Animation anim;
	private bool chestIsOpen = false;

	private Vector3 rayOrigin;
	private RaycastHit hit;
	private Ray ray;


	void Start()
	{
		rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
	}

	void Update(){
		ray = Camera.main.ViewportPointToRay (rayOrigin);
		if (Physics.Raycast (ray, out hit, 10.0f)) {
			if (hit.collider.name == name) {
				if (Input.GetKeyDown (KeyCode.E)) {
					chestIsOpen = !chestIsOpen;
					if (chestIsOpen) {
						OpenChestAnimation ();
						GetComponent<TextHint> ().textHint = "E - Close Chest";
						//ToDo When chest opened
					} else {
						CloseChestAnimation ();
						GetComponent<TextHint> ().textHint = "E - Open Chest";
						//ToDo When chest closed
					}
				}
			}
		}
	} 

	void OpenChestAnimation(){
		anim = chestDoor.GetComponent<Animation>();
		anim["ChestOpen"].speed = 1;
		anim.Play ("ChestOpen");
		audioOpen.Play(0);

	}
	void CloseChestAnimation(){
		anim["ChestOpen"].speed = -2;
		anim["ChestOpen"].time = anim["ChestOpen"].length;
		anim.Play("ChestOpen");
		audioClose.Play(0);
	}
}