using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Shop : MonoBehaviour
{
	public GameObject videoPlayer;
	public int timeToStop;
	bool flag = true;
    void Start()
    {
		videoPlayer.SetActive (false);
    }

	void OnTriggerEnter(Collider player)
	{
		if (flag) {
			videoPlayer.SetActive (true);
			Destroy (videoPlayer, timeToStop);
			flag = false;
		}
	}
}
