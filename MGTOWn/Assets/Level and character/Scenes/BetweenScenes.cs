using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetweenScenes : MonoBehaviour
{
    // Start is called before the first frame update
	void OnTriggerEnter(Collider other){
		SceneManager.LoadScene("Assets/Level and character/Scenes/Main level.unity");
		//SceneManager.LoadScene();
	}
}
