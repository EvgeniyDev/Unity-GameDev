using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameStory : MonoBehaviour
{
	public Text longText; 
	public GameObject fps;
	public GameObject UI_Player;
	public GameObject UI_PauseMenu;
	public GameObject UI_Author;
	public GameObject UI_Dialog;

    void Start()
    {
		Debug.Log ("Started");
		new Quest1().start();
		Debug.Log ("Started");
    }

	void Update()
	{
		
	}

	public void DisableFPS() { 
		//fps.GetComponent<FirstPersonController> ().enabled = false; 
	}
	public void EnableFPS() { 
		//fps.GetComponent<FirstPersonController> ().enabled = true; 
	}
	public void SetLongAuthorText(string AuthorText){
		for (int i = 0; i < AuthorText.Length; i++)
			longText.text += AuthorText[i];
	}
}





abstract class Quests : GameStory{

	string connection;
	protected IDbConnection dbcon;
	protected IDbCommand cmnd_read;
	protected IDataReader reader;
	protected string query;

	public enum LayoutUI{ Author, Dialog, NULL }

	public Quests(){
		connection = "URI=file:" + Application.dataPath + "/Resources/Storytelling/AllContent.db";
		dbcon = new SqliteConnection(connection);
		dbcon.Open ();
		cmnd_read = dbcon.CreateCommand();
	}

	/*
	public void ActiveScenarioLayout(bool flag, LayoutUI layoutType = LayoutUI.NULL){
		// true - only scenario
		// false - disable scenario
		if (flag) {
			DisableFPS ();
			UI_PauseMenu.SetActive(false);
			UI_Player.SetActive (false);
			if (layoutType == LayoutUI.Author) {
				UI_Dialog.SetActive (false);
				UI_Author.SetActive (true);
			}
			if (layoutType == LayoutUI.Dialog) {
				UI_Dialog.SetActive (true);
				UI_Author.SetActive (false);
			}
		} else {
			EnableFPS ();
			UI_PauseMenu.SetActive (true);
			UI_Player.SetActive (true);
			UI_Author.SetActive (false);
			UI_Dialog.SetActive (false);
		}
	}
*/
	public abstract void start ();
}





class Quest1 : Quests{

	public override void start ()
	{
		Debug.Log ("Quest 1");

		//ActiveScenarioLayout (true, LayoutUI.Author);

		query = "SELECT * FROM Phrases WHERE id_quest = 0;";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader ();

		while (reader.Read ()) {
			SetLongAuthorText(reader [2].ToString ());
			if (Input.anyKeyDown) continue;
		}

		dbcon.Close ();

		//ActiveScenarioLayout (false, LayoutUI.NULL);
	}

}
