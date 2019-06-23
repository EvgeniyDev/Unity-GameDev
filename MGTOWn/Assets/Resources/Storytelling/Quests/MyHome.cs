using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MyHome : Quest1
{
	void OnTriggerEnter()
    {
		if (getQuestText () == "Йти додому спати.")
  		{
  			EnableAuthor_UI ();
  			ClearLongAuthorText ();
  			SetLongAuthorText ( "День 1 закінчений.");

  			CurrentQuestSignDisable ();
  		}
  		if (getQuestText () == "Повернутися додому і лягти спати.")
  		{
  			EnableAuthor_UI ();
  			ClearLongAuthorText ();
  			SetLongAuthorText ( "День 2 закінчений.");
  		}
	}

	void OnTriggerExit(){
		if (getQuestText () == "Йти додому спати.") {
  			EnableAuthor_UI ();
  			ClearLongAuthorText ();
  			SetLongAuthorText ( "Сьогодні 25 червня 1456 року. \n\nБудет складний день ..." +
  				"Треба не забути зайти в виявлений в лісі будинок. Але з початку на площу.");
  			setQuestText ( "Зустрітися з Мелорі на площі.");
  		}
  		if (getQuestText () == "Повернутися додому і лягти спати.") {
 
  		}
	}
}
