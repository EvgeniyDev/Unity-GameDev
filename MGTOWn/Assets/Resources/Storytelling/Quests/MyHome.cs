using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MyHome : Quest1
{
	void OnTriggerEnter()
    {
		if (getQuestText () == "Идти домой спать.") {
			EnableAuthor_UI ();
			ClearLongAuthorText ();
			SetLongAuthorText ("День 1 закончен.");

            CurrentQuestSignDisable();
		}
		if (getQuestText () == "Вернуться домой и лечь спать.") {
			EnableAuthor_UI ();
			ClearLongAuthorText ();
			SetLongAuthorText ("День 2 закончен.");
		}
	}

	void OnTriggerExit(){
		if (getQuestText () == "Идти домой спать.") {
			mD3 = true;
			EnableAuthor_UI ();
			ClearLongAuthorText ();
			SetLongAuthorText ("Сегодня 25 июня 1456 года.\n\nБудет сложный день... " +
				"Надо не забыть зайти в обнаруженный в лесу дом. Но с начала на площадь.");
			setQuestText ("Встретиться с Мэлори на площаде.");
		}
		if (getQuestText () == "Вернуться домой и лечь спать.") {
			
		}
	}
}
