using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ButtonHandler : Quest1
{
	int counter = 0;
	public void  MeloryDialog()
	{
		switch (counter){
		case 0:
			Say ("Вы", "Простите, Мэлори.");
			break;
		case 1:
			Say ("Mэлори", "Ты разозлил меня, я дам тебе особое задание. Сходи в лес и принеси мне розу!");
			break;
		case 2:
			Say ("Вы", "Но... Вы отправляете меня на верную смерть...");
			break;
		case 3:
			Say ("Mэлори", "Значит такая у тебя судьба.");
			break;
		case 4:
			setQuestText ("Найти розу для Мэлори на краю леса.");
			EndMeloryDialog ();
			break;
		}
		counter++;
	}

	public void Say(string author, string text){
		saying = GameObject.FindGameObjectWithTag ("Saying").GetComponent<Text>();
		sayingText = GameObject.FindGameObjectWithTag ("Saying text").GetComponent<Text>();
		saying.text = author;
		sayingText.text = text;
	}

	public override void Start(){
		base.Start ();
	}
}
