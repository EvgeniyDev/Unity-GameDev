using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Quests : MonoBehaviour
{
    public static int questId;
    public static int subQuestId;

    public GameObject fps;
    protected Inventory inventory;
    public GameObject currentQuestMinimapSign;

    Text longText;
    protected Text questText;
    protected GameObject UI_Player;
    GameObject UI_PauseMenu;
    GameObject scenarioLayout;
	protected Canvas UI_Author;
    protected Canvas UI_Dialog;

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

	public void ClearLongAuthorText()
    {
		longText.text = "";
	}

	public void EnableAuthor_UI()
    {
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		UI_Player.SetActive (false);
		DisablePauseMenu();
		DisableFPS();

		UI_Author.enabled = true;
	}

	public void DisableAuthor_UI()
    {
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		UI_Player.SetActive (true);
		EnableFPS();
		EnablePauseMenu();

		UI_Author.enabled = false;
	}

	public void EnableDialog_UI()
    {
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		UI_Player.SetActive (false);
		DisablePauseMenu();
		DisableFPS();

		UI_Dialog.enabled = true;
	}

	public void DisableDialog_UI()
    {
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		UI_Player.SetActive (true);
		EnableFPS();
		EnablePauseMenu();

		UI_Dialog.enabled = false;
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
        currentQuestMinimapSign.transform.localPosition = new Vector3(x, y, 10);
    }

    public virtual void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryHolder").GetComponent<Inventory>();
        UI_Player = fps.transform.GetChild(2).gameObject;
        UI_PauseMenu = fps.transform.GetChild(3).gameObject;

		UI_Author = GameObject.FindGameObjectWithTag ("AuthorUI").GetComponent<Canvas>();
		UI_Dialog = GameObject.FindGameObjectWithTag ("Dialog").GetComponent<Canvas>();

		questText = UI_PauseMenu.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();

		longText = fps.transform.GetChild (4).transform.GetChild (0)
            .transform.GetChild (1).transform.GetChild (0).transform.GetChild (0).GetComponent<Text> ();
	}

	public void setQuestText(string text)
    {
		questText.text = text;
	}

	public string getQuestText()
    {
		return questText.text;
	}
}





