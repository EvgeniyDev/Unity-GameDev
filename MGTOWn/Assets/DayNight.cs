using UnityEngine;
using System;

public class DayNight : MonoBehaviour
{
	//Rotational Speed
	public float speed = 0f;
	public GameObject sky;
	public GameObject star;
	public Light sun;

	void Start()
    {
		sky.SetActive (true);
		star.SetActive (false);
	}

	bool flag = true;
	void Update ()
	{
		transform.Rotate(Time.deltaTime * speed, 0, 0, Space.Self);

		float angleX = Math.Abs(sun.transform.rotation.x);
		//Debug.Log (angleX +"\n");

		//night
		if ((angleX >= 0.707) && (flag)) {
			sky.SetActive (false);
			star.SetActive (true);
			sun.intensity = 0;
			RenderSettings.fog = false;
			flag = !flag;
		}

		//day
		if ((angleX <= 0.1) && (!flag)) {
			sky.SetActive (true);
			star.SetActive (false);
			sun.intensity = 1.5f;
			RenderSettings.fog = true;
			flag = !flag;
		}
	}
}