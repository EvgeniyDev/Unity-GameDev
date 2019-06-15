using UnityEngine;
using System.Collections;

class Quest1 : Quests
{
	private bool flag = false;

    public override void Start()
    {
        base.Start();

        //Debug.Log ("Quest 1");

		Vstuplenie (); 

        //dbcon.Close();
    }
		
    public void Update()
    {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ActiveScenarioLayout (false, LayoutUI.NULL);
			Q1 ();
		}

    }

	public void Vstuplenie()
	{
		ActiveScenarioLayout(true, LayoutUI.Author);

		query = "SELECT * FROM Phrases WHERE id_quest = 0;";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		while (reader.Read())
			SetLongAuthorText(reader[2].ToString());
		
		reader.Close ();
	}

	public void Q1()
	{
		ClearLongAuthorText ();

		ActiveScenarioLayout(true, LayoutUI.Author);

		query = "SELECT * FROM Phrases WHERE id_quest = 1;";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		while (reader.Read ())
			SetLongAuthorText (reader[2].ToString());
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (5);
	}
}
