using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestOpenScript : MonoBehaviour
{
	public GameObject chestDoor;
	public GameObject chestLock;
	public AudioSource audioOpen;
	public AudioSource audioClose;
	public TextMeshProUGUI Hint;

	protected Animation anim;
	private bool chestIsOpen = false;

	private Vector3 rayOrigin;
	private RaycastHit hit;
	private Ray ray;


	void Start()
	{
		rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
	}

	void OnTriggerStay(Collider col){
		ray = Camera.main.ViewportPointToRay (rayOrigin);
		if (Physics.Raycast (ray, out hit, 5.0f)) {
			if (hit.collider.CompareTag (chestLock.tag)) {
				Hint.text = "Press E to Open Chest";
				if (Input.GetKeyDown (KeyCode.E)) {
					chestIsOpen = !chestIsOpen;
					if (chestIsOpen) {
						OpenChestAnimation ();
						//ToDo When chest opened
					} else {
						CloseChestAnimation ();
						//ToDo When chest closed
					}
				}
			} else Hint.text = "";
		} else Hint.text = "";
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