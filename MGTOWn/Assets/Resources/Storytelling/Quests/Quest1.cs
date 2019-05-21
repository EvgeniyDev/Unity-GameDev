using UnityEngine;

class Quest1 : Quests
{
    public override void Start()
    {
        base.Start();

        //Debug.Log ("Quest 1");

        ActiveScenarioLayout(true, LayoutUI.Author);

        query = "SELECT * FROM Phrases WHERE id_quest = 0;";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while (reader.Read())
        {
           SetLongAuthorText(reader[2].ToString());
        }

        dbcon.Close();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActiveScenarioLayout(false, LayoutUI.NULL);
        }
    }
}
