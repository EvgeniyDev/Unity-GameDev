using UnityEngine;
using System.Collections;
using UnityEngine.UI;

class Quest1 : Quests
{
	private bool vstup = true;
	private bool text1 = false;
    
	private Vector3 rayOrigin;
	private RaycastHit hit;
	private Ray ray;

	Text saying;
	Text sayingText;

    public override void Start()
    {
        base.Start();

		Vstuplenie (); 
    }
		
	public void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Escape))
        {
			if (vstup)
            {
				vstup = false;
				text1 = true;
				ActiveScenarioLayout (false, LayoutUI.NULL);
				Q1 ();
				return;
			}

			if (text1)
            {
				text1 = false;
				ActiveScenarioLayout (false, LayoutUI.NULL);
				return;
			}
		}

		if (Input.GetKeyDown (KeyCode.E))
        {
			rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
			ray = Camera.main.ViewportPointToRay (rayOrigin);

			if (Physics.Raycast (ray, out hit, 10f))
            {
				if (hit.collider.CompareTag("Melory"))
					MeloryDialog ();
			}
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

		setQuestText ("Прийти в город Gynon к Мелори для получения задания.");

		GameObject Melory = GameObject.FindGameObjectWithTag ("Melory");
		Melory.SetActive (true);
	}

	public void MeloryDialog()
    {
		UI_Player.SetActive (false);
		UI_Dialog.SetActive (true);

		saying = GameObject.FindGameObjectWithTag ("Saying").GetComponent<Text>();
		sayingText = GameObject.FindGameObjectWithTag ("Saying text").GetComponent<Text>();

		saying.text = "Мэлори";
		sayingText.text = "-Ты заставил меня ждать!";
	}
}
