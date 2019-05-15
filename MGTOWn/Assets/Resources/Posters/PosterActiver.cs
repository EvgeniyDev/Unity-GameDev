using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PosterActiver : MonoBehaviour{
	
	public GameObject Poster;
	public Texture2D texture;

	private Vector3 rayOrigin;
	private RaycastHit hit;
	private bool isPosted = false;

	void Start()
	{
		rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
	}

	void Update()
	{
		if (!isPosted) {
			Ray ray = Camera.main.ViewportPointToRay (rayOrigin);
			if (Physics.Raycast (ray, out hit, 10.0f)) {
				if (hit.collider.name == Poster.name) {
					if (Input.GetKeyDown (KeyCode.E)) {
						Poster.GetComponent<Renderer> ().material.mainTexture = texture;
						isPosted = true;
						Poster.GetComponent<TextHint> ().textHint = "";
					} 
				}
			}
		}
	}

}
