using UnityEngine;
using UnityEngine.UI;

class HouseInForestTrigger : Quest1
{
	public override void Start()
    {
		base.Start (); 
    }

	bool flag = true;
	void OnTriggerEnter()
    {
		if (flag/* && subQuestId == 3*/) {
			flag = false;

			EnableAuthor_UI ();

			ClearLongAuthorText ();
			SetLongAuthorText ("Схоже тут хтось живе, не знав що крім Gynon`a і сіл тут ще є будинки. \n\n"+
  				"Ще повернуся сюди завтра.");

            subQuestId = 4;
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
