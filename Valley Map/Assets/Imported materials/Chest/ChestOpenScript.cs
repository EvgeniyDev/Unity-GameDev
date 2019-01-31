using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpenScript : MonoBehaviour
{
	public GameObject chestDoor;
	Animation anim;
	public AudioSource audioOpen;
	public AudioSource audioClose;

	void OnTriggerEnter (Collider other)
	{
		anim = chestDoor.GetComponent<Animation>();
		anim["ChestOpen"].speed = 1;
		anim.Play ("ChestOpen");
		audioOpen.Play(0);
	}
	void OnTriggerExit(Collider other)
	{
		anim["ChestOpen"].speed = -2;
		anim["ChestOpen"].time = anim["ChestOpen"].length;
		anim.Play("ChestOpen");
		audioClose.Play(0);
	}
}
