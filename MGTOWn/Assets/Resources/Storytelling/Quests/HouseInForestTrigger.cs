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

			ClearLongAuthorText ();

			ActiveScenarioLayout(true, LayoutUI.Author);
			SetLongAuthorText ("Дом");
		}
	}

	void Update()
    {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Escape))
			ActiveScenarioLayout (false, LayoutUI.NULL);
	}
}
