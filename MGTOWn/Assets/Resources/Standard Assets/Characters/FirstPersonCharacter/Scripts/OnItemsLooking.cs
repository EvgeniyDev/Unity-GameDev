using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnItemsLooking : MonoBehaviour
{
	//public 
	public TextMeshProUGUI Hint;

	private Vector3 rayOrigin;
	private RaycastHit hit;
	private Ray ray;

	void Start()
	{
		rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
	}

	void Update()
	{
		ray = Camera.main.ViewportPointToRay (rayOrigin);
		if (Physics.Raycast (ray, out hit, 10f)) {
			if (hit.collider.GetComponent<TextHint> () != null) 
				Hint.text = hit.collider.GetComponent<TextHint> ().textHint;
			else
				Hint.text = "";
		}
		else 
			Hint.text = "";
	}
}
