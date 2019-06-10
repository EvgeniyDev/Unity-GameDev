using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathScript : MonoBehaviour
{
    public FirstPersonController mainController;
    public PauseMenuScript pauseMenuScript;

    //public GameObject playerUI;
    public GameObject deathScreen;
    public GameObject gameStory;
    public Image fadeInImage;

    [Header ("Death screen buttons")]
    public Button respawn;
    public Button backToMainMenu;

    Animation deathAnimation;

    void Start()
    {
        deathAnimation = GetComponent<Animation>();
    }

    public void Die()
    {
        deathAnimation.Play();
        fadeInImage.color = Color.clear;

        Time.timeScale = 0.05f;

        mainController.enabled = false;
        pauseMenuScript.enabled = false;
        //playerUI.SetActive(false);
        gameStory.SetActive(false);
        deathScreen.SetActive(true);

        Invoke("DeathScreenFadeIn", 0.25f);
    }

    void DeathScreenFadeIn()
    {
        StartCoroutine(FadeIn());

        CancelInvoke("DeathScreenFadeIn");
    }

    IEnumerator FadeIn()
    {
        Time.timeScale = 0;

        Color tempColor = fadeInImage.color;

        for (float alpha = 0f; alpha <= 1.05f; alpha += 0.025f)
        {
            tempColor.a = alpha;
            fadeInImage.color = tempColor;
            yield return new WaitForSecondsRealtime(0.05f);
        }

        respawn.gameObject.SetActive(true);
        backToMainMenu.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Respawn()
    {
        //Need save&load system to be implemented

        Debug.Log("Respawned");
    }

    public void ToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main menu");
    }
}
