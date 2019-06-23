using UnityEngine;
using UnityEngine.UI;

class ButtonHandler : Quest1
{
	int counter = 0;
	public void MeloryDialog()
	{
		if (GameObject.FindGameObjectWithTag ("Saying text").GetComponent<Text> ().text == "Выполняй мои задания, а не шляйся тут!")
        {
			EndDialog ();
			return;
		}
		if (GameObject.FindGameObjectWithTag ("Saying text").GetComponent<Text> ().text == "Давай встретимся позже!") {
			EndDialog ();
			return;
		}

		switch (counter)
        {
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
            EndDialog ();
			break;

		case 5:
			Say ("Вы", "Я выполнил Ваше задание, Мэлори. Держите розу.");
			break;
		case 6:
			Say ("Мэлори", "А она мне уже не нужна. Оставь себе. Приходи завтра и получишь новое задание.");
            break;
		case 7:
			setQuestText ("Идти домой спать.");

			EndDialog ();
			EnableAuthor_UI ();
			ClearLongAuthorText ();
			SetLongAuthorText ("Кажеться, я все сделал... Можно отправлять спать.");
			break;
		case 8:
			Say ("Вы", "Зачем Вам жало пчелы?");
			break;
		case 9:
			Say ("Мэлори", "Я хочу. В \"Правах и Обязанностях\" сказано, что если я хочу, то ты должен делать. Делай.");
			break;
		case 10:
			Say ("Вы", "Я Вас понял, Мэлори.");
			break;
		case 11:
			Say ("Мэлори", "Вперед! Не задерживайся");
			break;
		case 12:
			setQuestText ("Найти оружие в сундуке на площаде Gynon.");
			//ToDo sign transform //currentQuestMinimapSign.transform.position = new Vector3 (385, -384, 496);
			EndDialog ();
			break;
		case 13:
			Say ("Mэлори", "Отдавай его мне. На сегодня хватит, до встречи завтра.");
			break;
		case 14:
			setQuestText ("Посетить дом в лесу.");
			//ToDo sign transform //currentQuestMinimapSign.transform.position = new Vector3 (385, -384, 496);
			EndDialog ();
			EnableAuthor_UI ();
			ClearLongAuthorText ();
			SetLongAuthorText ("Теперь настало время узнать кто живет в том доме. Главное чтоб никто из жителей не заметил куда я ушел.");
			osbertCanTalk = true;
			oD1 = true;
			break;
		case 15:
			Say ("Вы", "Здравствуй. Я не знал, что тут кто-то живет.");
			break;
		case 16:
			Say ("Осберт", "Твое невежество не критично, я держусь в тени, отдалившись от границ Gynon'a.");
			break;
		case 17:
			Say ("Вы", "Но зачем?");
			break;
		case 18:
			Say ("Осберт: ", "Ты когда-нибудь пробовал не выполнять задания женщин из города? Когда-то решимость противоречить переменила мою жизнь.");
			break;
		case 19:
			Say ("Вы", "Нет, выполнять их задания это мой долг, это долг каждого муж...");
			break;
		case 20:
			Say ("Осберт", "Мужчины? Вы не мужчины... Вы прислуга...");
			break;
		case 21:
			Say ("Вы", "Но... но мы...");
			break;
		case 22:
			Say ("Осберт: ", "Ты слышал что-то о таком величественном замысле как \"Город MGTOWn\"?");
			break;
		case 23:
			Say ("Вы", "Нет.");
			break;
		case 24:
			Say ("Осберт", "MGTOWn - дело всей моей жизни. MGTOWn - город без неравенств, величественный и могущественный город.");
			break;
		case 25:
			Say ("Вы", "А где находится этот город? ");
			break;
		case 26:
			Say ("Осберт: ", "Не все так просто, дорогой друг, этого города нет на новых картах. Когда-то MGTOWn существовал, но потом был переименован в Gynon, где власть сосредоточена в руках женщин.");
			break;
		case 27:
			Say ("Вы", "Но как ты узнал об этом городе?");
			break;
		case 28:
			Say ("Осберт", "Мой прадед был родом оттуда, все детство он рассказывал мне сказки о чудесном месте, где царит гармония. Потом рассказывал как город был захвачен, как прошло свержение короля и королевы.");
			break;
		case 29:
			Say ("Вы", "\"Короля\"?");
			break;
		case 30:
			Say ("Осберт: ", "Да, \"король\" это мужчина, имеющий власть вместе с королевой поровну. ");
			break;
		case 31:
			Say ("Вы", "Никогда не слышал такого слова.");
			break;
		case 32:
			Say ("Осберт: ", "Сейчас все надежды на равноправие утрачены... Мой прадед перед смертью сошел с ума: он схватил единственный рукописный документ, которой у нас тут был, и ушел в город. Он назывался \"Права и Обязанности\". А ведь мы хотели научиться читать то, что там написано... ");
			break;
		case 33:
			Say ("Вы", "У меня есть этот документ.");
			break;
		case 34:
			Say ("Осберт", "Что?!?!");
			break;
		case 35:
			Say ("Вы", "Несколько лет назад проходящий старец отдал мне документ. Благодаря ему я научился писать и читать.");
			break;
		case 36:
			Say ("Осберт: ", "Значит не все потеряно!!! Мы вернем справедливость в этот мир.");
			break;
		case 37:
			Say ("Вы", "Но как?");
			break;
		case 38:
			Say ("Осберт", "Встретимся завтра, я буду ждать тебя.");
			break;
		case 39:
			EndDialog ();
			EnableAuthor_UI ();
			ClearLongAuthorText ();
			setQuestText ("Вернуться домой и лечь спать.");
			SetLongAuthorText ("Меня давно посещали мысли о том что в нашем мире слишком много несправедливости, но я не ожидал что встречу человека, " +
				"который будет согласен с моим скромным мнением. Завтра я обязательно вернусь к Осберту, а сейчас - время спать.");
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
