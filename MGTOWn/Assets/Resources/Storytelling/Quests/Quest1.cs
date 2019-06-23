using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

class Quest1 : Quests
{
	protected bool vstup = true, text1 = false, bee = false;
	protected bool mD1 = false, mD2 = false;
	protected bool oD1 = false;
    
	Vector3 rayOrigin;
	RaycastHit hit;
	Ray ray;

	protected Text saying;
	protected Text sayingText;
	protected Button next;

    public override void Start()
    {
        base.Start();

        questId = 0;
        DisableDialog_UI();
        DisableAuthor_UI();
    }
		
	public void Update()
	{
        if (subQuestId == 0)
        {
            EnableAuthor_UI();
            Vstuplenie();
        }

		if (subQuestId == 1 && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Escape)))
        {
			if (vstup)
            {
				vstup = false;
				text1 = true;
				Q1 ();
				return;
			}

			if (text1)
            {
				text1 = false;
				DisableAuthor_UI ();

                subQuestId = 2;

                return;
			}
		
			try
            {
                DisableAuthor_UI ();
            }
            catch (Exception){} 

		}

		if (Input.GetKeyDown (KeyCode.E))
        {
			rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
			ray = Camera.main.ViewportPointToRay (rayOrigin);

			if (Physics.Raycast (ray, out hit, 10f))
            {
				if (hit.collider.CompareTag ("Melory"))
                {
					EnableDialog_UI ();

					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					DisableFPS ();

					saying = GameObject.FindGameObjectWithTag ("Saying").GetComponent<Text>();
					sayingText = GameObject.FindGameObjectWithTag ("Saying text").GetComponent<Text>();
					next = GameObject.FindGameObjectWithTag ("Next").GetComponent<Button>();

					if (/*subQuestId == 2 && */mD1)
                    {
						mD1 = false;
						saying.text = "Мелорі";
						sayingText.text = "Ти змусив мене чекати!";

                        subQuestId = 3;

                        SetCurrentQuestSignPosition(9.5f, -9f);

                        return;
					}
                    
					if (/*subQuestId == 5 && */mD2)
                    {
						mD2 = false;
						saying.text = "Мелорі";
						sayingText.text = "Я сподівалася що більше не побачу тебе!";

                        SetCurrentQuestSignPosition(-7.5f, 1.8f);

                        subQuestId = 6;
                        
						return;
					}

					if (getQuestText() == "Зустрітися з Мелорі на площі.") {
						saying.text = "Мелорі";
						sayingText.text = "Відразу до справи!  Ти повинен принести жало бджоли.";
						return;
					}

					if (bee && inventory.CheckItemInInventory("Hornet sting"))
                    {
						bee = false;
						saying.text = "Ви";
						sayingText.text = "Я приніс Вам жало бджоли.";
						return;
					}

                    saying.text = "Мелорі";
                    sayingText.text = "Виконуй мої завдання, а не шляйся тут!";
				}

				if (hit.collider.CompareTag ("Osbert")) {
					EnableDialog_UI ();

					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					DisableFPS ();

					saying = GameObject.FindGameObjectWithTag ("Saying").GetComponent<Text> ();
					sayingText = GameObject.FindGameObjectWithTag ("Saying text").GetComponent<Text> ();
					next = GameObject.FindGameObjectWithTag ("Next").GetComponent<Button> ();

					if (oD1) {
						oD1 = false;
						saying.text = "Осберт";
						sayingText.text = "Здрастуй, що заблукав в настільки далекі краї подорожній. ";
						return;
					}

					saying.text = "Осберт";
					sayingText.text = "Давай зустрінемося пізніше!";		
				}

				if (hit.collider.CompareTag ("Knife"))
				{
					bee = true;
					setQuestText ("Вбити бджолу і принести жало Мелорі.");
				}

				if (/*subQuestId == 4 && */hit.collider.CompareTag ("Rose"))
                {
					setQuestText ("Віддати троянду Мелорі.");
                    SetCurrentQuestSignPosition(8.6f, 4.9f);

                    mD2 = true;
                    subQuestId = 5;
                }
			}
		}
    }

	public void Vstuplenie()
	{
		SetLongAuthorText("Для початку хочеться повідати читачеві про те, яким чином я навчився писати "+
  "І чому моє життя відрізняється від життя інших чоловіків. \n\n Був холодний вечір січня 1443 року."  +
  "У будинку постукали. Неспішно підійшовши до дверей, я почув голос, дуже хрипкий голос, і відкрив двері." +
  "На порозі стояв старець, в його руках був Клочек папери з якимось текстом. Що відбувається? Ніколи" +
  "Раніше я не бачив щоб чоловікам було дозволено торкатися до рукописів, ми ж все одно не вміємо читати." +
  "Куди бігти? Кому доповідати? Поруч не було жодної жінки. Помітивши мою паніку, старець сказав: \n \n" +
  "-Нарешті-то я знайшов молодого чоловіка. Тримай цей сувій, з його допомогою ти знайдеш відповіді на всі навколишні" +
  "Тебе загадки і зможеш позбавити світ від несправедливості. На жаль, мені залишилося зовсім мало часу," +
  "Бережи цей сувій, його назва - \" Права і обов'язки \", навчися читати з його допомогою. \n \n Закончів" +
  "Говорити, старець вийшов з дому і розчинився в темряві ночі. \n\n * \n\nКаждий день на головній площі" +
  "Gynon'а було урочисте читання \" Прав і обов'язків \". Цей документ був сформований ще сотні" +
  "Років тому і з тих пір в ньому нічого не змінилося. У першому рядку були написані права жінок, а після -" +
  "Обов'язки чоловіків. Кожен в місті напам'ять пам'ятає ці слова \" Жінка має право робити все що вона хоче.  "+
  "Чоловіки зобов'язані виконувати всі бажання жінок. Чоловіки повинні бути добрими по відношенню до жінок. Якщо жінці" +
  "Погано, чоловік зобов'язаний страждати подвійно ... \" Далі йде ще багато подібних пунктів, але я не вважаю за потрібне "+
  "Перераховувати їх все тут. \n \n Там, на головній площі, сховавшись за сіном, я слухав читання \" Прав і обов'язків \"" +
  ", Уважно розглядаючи слова в тому свиті, що дав мені старець. Я почав зіставляти звуки з буквами," +
  "Намагаючись запам'ятати соответсвия. \n \nСпустя кілька місяців я вже міг сам читат сувій. \n \n Іменно так я і" +
  "Навчився читати. Можливо перший чоловік, який це зміг. Тепер, через роки тренувань читання і письма," +
  "Я почав писати свій щоденник. \n");

        subQuestId = 1;
	}
		
		
	public void Q1()
	{
		ClearLongAuthorText ();
		SetLongAuthorText("Сьогодні 24 червня 1456 року. \n \n Мій ранок почався як завжди: треба прийти на головну площу "+
  "Міста Gynon і отримати чергове завдання від Мелорі.");

		setQuestText ("Прийти в місто Gynon до Мелорі для отримання завдання.");

        SetCurrentQuestSignPosition(8.6f, 4.9f);

        mD1 = true;
    }

	public void EndDialog()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		EnableFPS ();
		DisableDialog_UI ();
    }

}
