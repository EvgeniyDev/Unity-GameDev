using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using System.Threading;

public class BetweenScenes : MonoBehaviour
{
    
	public string level;
	//public GameObject videoPlayer;
	//public int timeToStop;
	//public FirstPersonController fps;

	//void Start()
	//{
	//	videoPlayer.SetActive (false);
	//}

	void OnTriggerEnter(Collider other){
		//Thread t = new Thread (showBG);
		//t.Start();
		Debug.Log("Assets/Level and character/Scenes/"+level+".unity");
		SceneManager.LoadScene("Assets/Level and character/Scenes/"+level+".unity");
	}

	//void showBG(){
	//	videoPlayer.SetActive (true);
	//	Destroy (videoPlayer, 10);
	//}
}
