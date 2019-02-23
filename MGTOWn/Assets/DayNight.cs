using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DayNight : MonoBehaviour
{
	//Rotational Speed
	public float speed = 0f;
	public GameObject sky;
	public GameObject star;
	public GameObject sun;

	void Start(){
		sky = GameObject.Find("Terrain/Sky/Low");
		star = GameObject.Find("Terrain/Sky/LowStar");
		sun = GameObject.Find("Terrain/Sun");
		sky.SetActive (true);
		star.SetActive (false);
	}

	bool flag = true;
	void Update ()
	{
		transform.Rotate(Time.deltaTime * speed, 0, 0, Space.Self);

		float angleX = Math.Abs(sun.transform.rotation.x);
		Debug.Log (angleX +"\n");


		if (angleX >= 0.675) {
			if (flag) {
				sky.SetActive (false);
				star.SetActive (true);
				flag = !flag;
			}
		}
		if (angleX <= 0.1) {
			if (!flag) {
				sky.SetActive (true);
				star.SetActive (false);
				flag = !flag;
			}
		}
			
		//sky.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0);
	}
}