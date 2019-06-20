using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PlayerUI;
    public GameObject PauseMenu;
    public GameObject Tooltip;
    public FirstPersonController fps;
    public CurrentWeaponSlot weaponSlot;
       
    bool isOpened;

    void Awake()
    {
        isOpened = false;
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            isOpened = !isOpened;

            if (isOpened)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                PlayerUI.SetActive(false);
                PauseMenu.SetActive(true);

                fps.enabled = false;
            }
            else
            {
                CloseMenu();
            }
        }
    }

    public void CloseMenu()
    {
        if (isOpened) isOpened = !isOpened;

		Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PlayerUI.SetActive(true);
        PauseMenu.SetActive(false);

        fps.enabled = true;

        Tooltip.SetActive(false);

        weaponSlot.isOver = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
