using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

class Quests : MonoBehaviour
{
    string connection;
    protected IDbConnection dbcon;
    protected IDbCommand cmnd_read;
    protected IDataReader reader;
    protected string query;

    public GameObject fps;
    public GameObject currentQuestMinimapSign;

    Text longText;
    protected GameObject UI_Player;
    GameObject UI_PauseMenu;
    GameObject scenarioLayout;
    GameObject UI_Author;
    public GameObject UI_Dialog;
	Text questText;

    public enum LayoutUI { Author, Dialog, NULL }

    public void DisableFPS()
    {
        fps.GetComponent<FirstPersonController>().enabled = false;
    }

    public void EnableFPS()
    {
        fps.GetComponent<FirstPersonController>().enabled = true;
    }

    public void EnablePauseMenu()
    {
        fps.GetComponent<PauseMenuScript>().enabled = true;
    }

    public void DisablePauseMenu()
    {
        fps.GetComponent<PauseMenuScript>().enabled = false;
    }

    public void SetLongAuthorText(string AuthorText)
    {
        for (int i = 0; i < AuthorText.Length; i++)
            longText.text += AuthorText[i];
    }

	public void ClearLongAuthorText(){
		longText.text = "";
	}

    public void ActiveScenarioLayout(bool flag, LayoutUI layoutType = LayoutUI.NULL)
    {
        // true - only scenario
        // false - disable scenario

        if (flag)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            DisablePauseMenu();

            DisableFPS();

            UI_PauseMenu.SetActive(false);
            UI_Player.SetActive(false);
            scenarioLayout.SetActive(true);

            if (layoutType == LayoutUI.Author)
            {
                UI_Dialog.SetActive(false);
                UI_Author.SetActive(true);
            }
            if (layoutType == LayoutUI.Dialog)
            {
                UI_Dialog.SetActive(true);
                UI_Author.SetActive(false);
            }
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            EnableFPS();

            EnablePauseMenu();

            scenarioLayout.SetActive(false);
            UI_PauseMenu.SetActive(false);
            UI_Player.SetActive(true);
            UI_Author.SetActive(false);
            UI_Dialog.SetActive(false);
        }
    }

    public void CurrentQuestSignEnable()
    {
        currentQuestMinimapSign.SetActive(true);
    }

    public void CurrentQuestSignDisable()
    {
        currentQuestMinimapSign.SetActive(false);
    }

    public void SetCurrentQuestSignPosition(float x, float y)
    {
        currentQuestMinimapSign.transform.localPosition = new Vector3(x, y, 3);
    }

    public virtual void Start()
    {
        UI_Player = fps.transform.GetChild(2).gameObject;
        UI_PauseMenu = fps.transform.GetChild(3).gameObject;

        scenarioLayout = fps.transform.GetChild(4).gameObject;
        UI_Author = scenarioLayout.transform.GetChild(0).gameObject;

		questText = GameObject.FindGameObjectWithTag ("Quest").GetComponent<Text>();
        longText = UI_Author.transform.GetChild(1).transform.GetChild(0)
                    .transform.GetChild(0).GetComponent<Text>();


        connection = "URI=file:" + Application.dataPath + "/Resources/Storytelling/AllContent.db";
        dbcon = new SqliteConnection(connection);
        dbcon.Open();
        cmnd_read = dbcon.CreateCommand();
    }

	public void setQuestText(string text){
		questText.text = text;
	}
		
}





