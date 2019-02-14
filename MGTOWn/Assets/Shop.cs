using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityStandardAssets.Characters.FirstPerson;

public class Shop : MonoBehaviour
{
	public GameObject videoPlayer;
	public int timeToStop;
	int flag = 0;
	public FirstPersonController fps;
    void Start()
    {
		videoPlayer.SetActive (false);
    }
		
	void OnTriggerEnter()
	{
		if (flag == 0) {
			//fps.GetComponent<MouseLook>().XSensitivity = 0;
			//this.gameObject.GetComponent<MouseLook>().YSensitivity = 0;
			videoPlayer.SetActive (true);
			Destroy (videoPlayer, timeToStop);
			flag = 1;
		}
		if (flag == 1) {
			//this.gameObject.GetComponent<MouseLook>().XSensitivity = 2;
			//this.gameObject.GetComponent<MouseLook>().YSensitivity = 2;
			inventOn = true;
			flag = 2;
		}
	}
		
	bool inventOn = false;
	void OnTriggerStay(){
		if (Input.GetKey (KeyCode.E)) {
			if (inventOn) {
				//shopInventory.enabled = false;
			} else {
				//shopInventory.enabled = true;
			}
			inventOn = !inventOn;
		}
	}

}
