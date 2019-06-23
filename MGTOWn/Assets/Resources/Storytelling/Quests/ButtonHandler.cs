using UnityEngine;
using UnityEngine.UI;

class ButtonHandler : Quest1
{
	int counter = 0;
	public void MeloryDialog()
	{
		if (GameObject.FindGameObjectWithTag ( "Saying text"). GetComponent<Text>().text == "Виконуй мої завдання, а не шляйся тут!")
  		{
  			EndDialog ();
  			return;
  		}
  		if (GameObject.FindGameObjectWithTag ( "Saying text"). GetComponent<Text>().text == "Давай зустрінемося пізніше!") {
  			EndDialog ();
  			return;
  		}

  		switch (counter)
  		{
  			case 0:
  				Say ( "Ви", "Вибачте, Мелорі.");
  				break;
  			case 1:
  				Say ( "Mелорі", "Ти розлютив мене, я дам тобі особливе завдання. Сходи в ліс і принеси мені троянду!");
  				break;
  			case 2:
  				Say ( "Ви", "Але ... Ви відправляєте мене на вірну смерть ...");
  				break;
  			case 3:
  				Say ( "Mелорі", "Значить така у тебе доля.");
  				break;
  			case 4:
  				setQuestText ( "Знайти троянду для Мелорі на краю лісу.");
  				EndDialog ();
  				break;
  			case 5:
  				Say ( "Ви", "Я виконав Ваше завдання, Мелорі. Тримайте троянду.");
  				break;
  			case 6:
  				Say ( "Мелорі", "А вона мені вже не потрібна. Залиш собі. Приходь завтра і отримаєш нове завдання.");
  				break;
  			case 7:
  				setQuestText ( "Йти додому спати.");
  				EndDialog ();
  				EnableAuthor_UI ();
  				ClearLongAuthorText ();
  				SetLongAuthorText ( "Здається, я все зробив ... Можна відправляти спати.");
  				break;
  			case 8:
  				Say ( "Ви", "Навіщо Вам жало бджоли?");
  				break;
  			case 9:
  				Say ( "Мелорі", "Я хочу. В \"Права та обов'язки\" сказано, що якщо я хочу, то ти повинен робити. Роби.");
  				break;
  			case 10:
  				Say ( "Ви", "Я Вас зрозумів, Мелорі.");
  				break;
  			case 11:
  				Say ( "Мелорі", "Вперед! Чи не затримуйся");
  				break;
  			case 12:
  				setQuestText ( "Знайти зброю в скрині на площі Gynon.");
  				EndDialog ();
  				break;
 			case 13:
  				Say ( "Mелорі", "Віддавай його мені. На сьогодні вистачить, до зустрічі завтра.");
  				break;
  			case 14:
  				setQuestText ( "Відвідати будинок в лісі.");
  				// ToDo sign transform //currentQuestMinimapSign.transform.position = new Vector3 (385, -384, 496);
  				EndDialog ();
  				EnableAuthor_UI ();
  				ClearLongAuthorText ();
  				SetLongAuthorText ( "Тепер настав час дізнатися хто живе в тому будинку. Головне щоб ніхто з жителів не помітив куди я пішов.");
  				oD1 = true;
  				break;
  			case 15:
  				Say ( "Ви", "Здрастуй. Я не знав, що тут хтось живе.");
 				break;
  			case 16:
  				Say ( "Осберт", "Твоє невігластво не критично, я тримаюся в тіні, віддалившись від кордонів Gynon'a.");
  				break;
  			case 17:
  				Say ( "Ви", "Але навіщо?");
  				break;
  			case 18:
  				Say ( "Осберт", "Ти коли-небудь пробував не виконувати завдання жінок з міста? Колись рішучість суперечити змінила моє життя.");
  				break;
  			case 19:
  				Say ( "Ви", "Ні, виконувати їх завдання це мій обов'язок, це обов'язок кожного чоловік ...");
  				break;
  			case 20:
  				Say ( "Осберт", "Чоловіки? Ви не чоловіки ... Ви прислуга ...");
  				break;
  			case 21:
  				Say ( "Ви", "Але ... але ми ...");
  				break;
  			case 22:
  				Say ( "Осберт", "Ти чув щось про таке величному задумі як \" Місто MGTOWn \"?");
  				break;
  			case 23:
  				Say ( "Ви", "Ні.");
  				break;
  			case 24:
  				Say ( "Осберт", "MGTOWn - справа всього мого життя. MGTOWn - місто без нерівностей, величний і могутній місто.");
  				break;
  			case 25:
  				Say ( "Ви", "А де знаходиться це місто?");
  				break;
  			case 26:
  				Say ( "Осберт", "Не все так просто, любий друже, цього міста немає на нових картах. Колись MGTOWn існував, але потім був перейменований в Gynon, де влада зосереджена в руках жінок.");
  				break;
  			case 27:
  				Say ( "Ви", "Але як ти дізнався про це місто?");
  				break;
  			case 28:
  				Say ( "Осберт", "Мій прадід був родом звідти, все дитинство він розповідав мені казки про чудовому місці, де панує гармонія. Потім розповідав як місто було захоплене, як пройшло повалення короля і королеви.");
  				break;
  			case 29:
  				Say ( "Ви", "\" Короля \"?");
  				break;
  			case 30:
  				Say ( "Осберт", "Так, \"король\" це чоловік, який має владу разом з королевою порівну.");
  				break;
  			case 31:
  				Say ( "Ви", "Ніколи не чув такого слова.");
  				break;
  			case 32:
  				Say ( "Осберт", "Зараз всі надії на рівноправність втрачені ... Мій прадід перед смертю збожеволів: він схопив єдиний рукописний документ, якій у нас тут був, і пішов в місто. Він називався \" Права і Обов'язки \" .Але ж ми хотіли навчитися читати те, що там написано ... ");
  				break;
  			case 33:
  				Say ( "Ви", "У мене є цей документ.");
  				break;
  			case 34:
  				Say ( "Осберт", "Що?!?!");
  				break;
  			case 35:
  				Say ( "Ви", "Кілька років тому проходить старець віддав мені документ. Завдяки йому я навчився писати і читати.");
  				break;
  			case 36:
  				Say ( "Осберт", "Значить не все втрачено !!! Ми повернемо справедливість в цей світ.");
  				break;
  			case 37:
  				Say ( "Ви", "Але як?");
  				break;
  			case 38:
  				Say ( "Осберт", "Зустрінемось завтра, я буду чекати тебе.");
  				break;
  			case 39:
  				EndDialog ();
  				EnableAuthor_UI ();
  				ClearLongAuthorText ();
  				setQuestText ( "Назад додому і лягти спати.");
  				SetLongAuthorText ( "Мене давно відвідували думки про те що в нашому світі дуже багато несправедливості, але я не очікував що зустріч людини," +
  					"Який буде згоден з моїми скромними думкою. Завтра я обов'язково повернуся до Осберту, а зараз - час спати.");
  				break;
  		}
		counter++;
	}

	public void Say(string author, string text)
    {
		saying = GameObject.FindGameObjectWithTag ("Saying").GetComponent<Text>();
		sayingText = GameObject.FindGameObjectWithTag ("Saying text").GetComponent<Text>();
		saying.text = author;
		sayingText.text = text;
	}

	public override void Start()
    {
		base.Start ();
	}
}
