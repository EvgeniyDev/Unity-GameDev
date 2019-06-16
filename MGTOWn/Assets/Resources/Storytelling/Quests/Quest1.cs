using UnityEngine;
using System.Collections;

class Quest1 : Quests
{
    public GameObject Melory;
    
    public override void Start()
    {
        base.Start();

        questId = 0;
        subQuestId = 0;

        CurrentQuestSignDisable();
    }
		
    void Update()
    {
        if (subQuestId == 0) Vstuplenie();
        if (subQuestId == 1) Q1();
        if (subQuestId == 2) MeloryDialog1();
    }

    public void Vstuplenie()
    {
        if (!isTextPrinted)
        {
            ActiveScenarioLayout(true, LayoutUI.Author);

            query = "SELECT * FROM Phrases WHERE id_quest = 0;";
            cmnd_read.CommandText = query;
            reader = cmnd_read.ExecuteReader();

            while (reader.Read())
                SetLongAuthorText(reader[2].ToString());

            reader.Close();

            isTextPrinted = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            subQuestId = 1;
            isTextPrinted = false;
        }
    }

    public void Q1()
    {
        if (!isTextPrinted)
        {
            ClearLongAuthorText();

            ActiveScenarioLayout(true, LayoutUI.Author);

            query = "SELECT * FROM Phrases WHERE id_quest = 1;";
            cmnd_read.CommandText = query;
            reader = cmnd_read.ExecuteReader();

            while (reader.Read())
                SetLongAuthorText(reader[2].ToString());

            reader.Close();

            isTextPrinted = true;
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            subQuestId = 2;

            ActiveScenarioLayout(false, LayoutUI.NULL);

            SetCurrentQuestSignPosition(2.6f, 1.45f);
            CurrentQuestSignEnable();
        }
    }

    public void MeloryDialog1()
    {

    }
}
