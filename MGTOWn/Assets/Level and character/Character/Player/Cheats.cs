using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Cheats : MonoBehaviour
{
    public GameObject cheatHint;

    FirstPersonController firstPersonController;
    PlayerStats playerStats;

    //cheats
    string[] giveAxeCheat;
    int giveAxeCheatIndex;

    string[] manyHPCheat;
    int manyHPIndex;

    string[] fastRunCheat;
    int fastRunIndex;

    bool manyHPCheatActivated;
    bool fastRunCheatActivated;

    float tempSpeed;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        firstPersonController = GetComponent<FirstPersonController>();

        giveAxeCheat = new string[] { "g", "i", "v", "e", "a", "x", "e", "1" };
        manyHPCheat = new string[] { "m", "a", "n", "y", "h", "p" };
        fastRunCheat = new string[] { "f", "a", "s", "t", "r", "u", "n" };

        giveAxeCheatIndex = 0;
        manyHPIndex = 0;
        fastRunIndex = 0;

        manyHPCheatActivated = false;
        fastRunCheatActivated = false;

        tempSpeed = firstPersonController.m_RunSpeed;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(manyHPCheat[manyHPIndex]))
            {
                manyHPIndex++;
            }
            else
            {
                manyHPIndex = 0;
            }

            if (Input.GetKeyDown(giveAxeCheat[giveAxeCheatIndex]))
            {
                giveAxeCheatIndex++;
            }
            else
            {
                giveAxeCheatIndex = 0;
            }

            if (Input.GetKeyDown(fastRunCheat[fastRunIndex]))
            {
                fastRunIndex++;
            }
            else
            {
                fastRunIndex = 0;
            }
        }

        if (giveAxeCheatIndex == giveAxeCheat.Length)
        {
            StartCoroutine(HintActivation());

            GameObject temp = Instantiate(Resources.Load<GameObject>("Weapons/Prefabs/Axe"));
            temp.name = "Axe";
            temp.transform.position = Camera.main.transform.position + 2 * Camera.main.transform.forward;

            giveAxeCheatIndex = 0;
        }

        if (manyHPIndex == manyHPCheat.Length)
        {
            StartCoroutine(HintActivation(manyHPCheatActivated));

            if (!manyHPCheatActivated)
            {
                playerStats.maxHealth = 100000;
            }
            else
            {
                playerStats.maxHealth = 100;
            }

            manyHPCheatActivated = !manyHPCheatActivated;

            playerStats.currentHealth = playerStats.maxHealth;

            manyHPIndex = 0;
        }

        if (fastRunIndex == fastRunCheat.Length)
        { 
            StartCoroutine(HintActivation(fastRunCheatActivated));

            if (!fastRunCheatActivated)
            {
                firstPersonController.m_RunSpeed = 100;
            }
            else
            {
                firstPersonController.m_RunSpeed = tempSpeed;   
            }

            fastRunCheatActivated = !fastRunCheatActivated;

            fastRunIndex = 0;
        }
    }

    IEnumerator HintActivation()
    {
        cheatHint.SetActive(true);

        cheatHint.GetComponent<Text>().text = "Cheatcode activated!";

        yield return new WaitForSeconds(5f);

        cheatHint.SetActive(false);
        cheatHint.GetComponent<Text>().text = string.Empty;
    }

    IEnumerator HintActivation(bool isActivated)
    {
        cheatHint.SetActive(true);

        if (!isActivated)
        {
            cheatHint.GetComponent<Text>().text = "Cheatcode activated!";
        }
        else
        {
            cheatHint.GetComponent<Text>().text = "Cheatcode deactivated!";
        }

        yield return new WaitForSeconds(5f);

        cheatHint.SetActive(false);
        cheatHint.GetComponent<Text>().text = string.Empty;
    }
}
