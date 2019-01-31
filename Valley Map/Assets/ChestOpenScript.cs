using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpenScript : MonoBehaviour
{
	public GameObject chestDoor;
	Animation anim;

	void OnTriggerEnter (Collider other)
	{
		anim = chestDoor.GetComponent<Animation>();
		anim["ChestOpen"].speed = 1;
		anim.Play ("ChestOpen");
	}
	void OnTriggerExit(Collider other)
	{
		anim["ChestOpen"].speed = -1;
		anim["ChestOpen"].time = anim["ChestOpen"].length;
		anim.Play("ChestOpen");
	}
}
