using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class womanScript : MonoBehaviour
{
	Animator animator;    

	void Start()
	{
		animator = GetComponent<Animator>();      
	}

	void Update()
	{
		transform.Translate(new Vector3(0, 0, 1.2f) * Time.deltaTime);

	}
}
