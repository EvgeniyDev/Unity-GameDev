using UnityEngine;
using UnityEngine.UI;

class HouseInForestTrigger : Quest1
{
	public override void Start()
    {
		base.Start ();
    }

	bool flag = true;
	void OnTriggerEnter(){
		if (flag) {
			flag = false;

			EnableAuthor_UI ();

			ClearLongAuthorText ();
			SetLongAuthorText ("Похоже тут кто-то живет, не знал что кроме Gynon`a и деревень тут еще есть дома.\n\n " +
				"Еще вернусь сюда завтра.");
		}
		entered = true;
	}

	bool entered = false;
	void Update()
    {
		if (entered && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Escape)))
			DisableAuthor_UI ();
		
	}
}
