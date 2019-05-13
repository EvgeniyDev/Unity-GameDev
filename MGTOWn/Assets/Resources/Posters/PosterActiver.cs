using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PosterActiver : MonoBehaviour
{
	public TextMeshProUGUI Hint;
	public GameObject Poster;
	public Texture2D texture;
	private Vector3 rayOrigin;
	private RaycastHit hit;
	private bool isPosted = false;

	void Start()
	{
		rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
		//texture = (Texture2D) Resources.Load ("Assets/Resources/Posters/MGTOWN0"); //poster
	}

	void OnTriggerExit (Collider col) 
	{
		Hint.text = "";
	}
	void OnTriggerStay (Collider col) 
	{
		if (!isPosted) {
			Ray ray = Camera.main.ViewportPointToRay (rayOrigin);
			if (Physics.Raycast (ray, out hit, 5.0f)) {
				if (hit.collider.tag == Poster.tag) {
					Hint.text = "Press E to put poster";
					if (Input.GetKeyDown (KeyCode.E)) {
						Poster.GetComponent<Renderer> ().material.mainTexture = texture;
						isPosted = true;
						Hint.text = "";
					}
				} else
					Hint.text = "";
			} else
				Hint.text = "";
		} else
			Hint.text = "";
	}

}
