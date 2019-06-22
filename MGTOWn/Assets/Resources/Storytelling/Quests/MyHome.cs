using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MyHome : Quest1
{
	void OnTriggerEnter(){
		if (getQuestText () == "Идти домой спать.") {
			EnableAuthor_UI ();
			ClearLongAuthorText ();
			SetLongAuthorText ("День 1 закончен.");
		}
	}
}
