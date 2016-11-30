using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public Canvas principalMenu;
	public Button level1;
	public Button level2;
	public Button level3;
	public Button exit;
	public Text level1Text;
	public Text level2Text;
	public Text level3Text;
	public Text exitText;
	public int focus;
	public int unlockedLevel;
	public Color unselectedBGColor;
	public Color selectedBGColor;
	public Color unselectedTextColor;
	public Color selectedTextColor;

	void Start () {

		unlockedLevel = Singleton.Instance.getUnlockedLevel();

		unselectedBGColor = new Color(0.529F, 0.407F, 0.239F, 1);
		selectedBGColor = new Color(0.364F, 0.305F, 0.227F, 1);
		unselectedTextColor = new Color(0.333F, 0.239F, 0.086F, 1);
		selectedTextColor = new Color(0.176F, 0.156F, 0.086F, 1);

		//Boton Iniciar Level1 - Initial state: Selected
		level1 = level1.GetComponent<Button> ();
		level1.image.color = selectedBGColor;
		level1Text = level1Text.GetComponent<Text>();
		level1Text.color = selectedTextColor;

		//Boton Iniciar Level2 - Initial state: Unselected
		level2 = level2.GetComponent<Button> ();
		level2.image.color = unselectedBGColor;
		level2Text = level2Text.GetComponent<Text> ();
		level2Text.color = unselectedTextColor;

		//Boton Iniciar Level3 - Initial state: Unselected
		level3 = level3.GetComponent<Button> ();
		level3.image.color = unselectedBGColor;
		level3Text = level3Text.GetComponent<Text>();
		level3Text.color = unselectedTextColor;

		//Boton Volver - Initial state: Unselected
		exit = exit.GetComponent<Button> ();
		exit.image.color = unselectedBGColor;
		exitText = exitText.GetComponent<Text>();
		exitText.color = unselectedTextColor;

		//focus manages button focus logic - initiate 0
		focus = 0;
	}

	public int CheckUnlockedLevel (string direction, int focus) {
		switch (direction) {
		case "up":
			switch (unlockedLevel) {
			case 1:
				if (focus == 1 || focus == 2) {
					focus = 0;
				}
				break;
			case 2:
				if (focus == 2) {
					focus = 1;
				}
				break;
			}
			break;
		case "down":
			switch (unlockedLevel) {
			case 1:
				if (focus == 1 || focus == 2) {
					focus = 3;
				}
				break;
			case 2:
				if (focus == 2) {
					focus = 3;
				}
				break;
			}
			break;
		}

		return focus;
	}

	public int MoveFocusUp(int focus) {

		if (focus != 0){
			focus = focus - 1;
		}

		focus = CheckUnlockedLevel ("up",focus);
	
		return focus;
	}

	public int MoveFocusDown(int focus) {

		if (focus != 3){
			focus = focus + 1;
		}

		focus = CheckUnlockedLevel ("down",focus);

		return focus;
	}

	void UpdateFocus(int focus){

		switch (focus) {
		case 0:
			level1.image.color = selectedBGColor;
			level2.image.color = unselectedBGColor;
			level3.image.color = unselectedBGColor;
			exit.image.color = unselectedBGColor;

			level1Text.color = selectedTextColor;
			level2Text.color = unselectedTextColor;
			level3Text.color = unselectedTextColor;
			exitText.color = unselectedTextColor;

			break;
		case 1:
			level1.image.color = unselectedBGColor;
			level2.image.color = selectedBGColor;
			level3.image.color = unselectedBGColor;
			exit.image.color = unselectedBGColor;

			level1Text.color = unselectedTextColor;
			level2Text.color = selectedTextColor;
			level3Text.color = unselectedTextColor;
			exitText.color = unselectedTextColor;
			break;
		case 2:
			level1.image.color = unselectedBGColor;
			level2.image.color = unselectedBGColor;
			level3.image.color = selectedBGColor;
			exit.image.color = unselectedBGColor;

			level1Text.color = unselectedTextColor;
			level2Text.color = unselectedTextColor;
			level3Text.color = selectedTextColor;
			exitText.color = unselectedTextColor;
			break;
		case 3:
			level1.image.color = unselectedBGColor;
			level2.image.color = unselectedBGColor;
			level3.image.color = unselectedBGColor;
			exit.image.color = selectedBGColor;
			level1Text.color = unselectedTextColor;
			level2Text.color = unselectedTextColor;
			level3Text.color = unselectedTextColor;
			exitText.color = selectedTextColor;
			break;
		}
	}

	void EnterPress (int focus){

		switch(focus){
		case 0:
            Singleton.Instance.setActualLevel(1);
			SceneManager.LoadScene ("Level 1");
			break;
		case 1:
            Singleton.Instance.setActualLevel(2);
            SceneManager.LoadScene ("Level 2");
			break;
		case 2:
            Singleton.Instance.setActualLevel(3);
            SceneManager.LoadScene ("Level 3");
			break;
		case 3:
			Destroy(gameObject);
			Instantiate (principalMenu);
			break;
		}
	}

	void Update () {

		if (Input.GetKeyDown ("up")) {
			focus = MoveFocusUp (focus);
			//Repintar focus
			UpdateFocus(focus);
		}

		if (Input.GetKeyDown ("down")) {
			focus = MoveFocusDown (focus);
			//Repintar focus
			UpdateFocus(focus);
		}

		if(Input.GetKeyDown ("return")){
			EnterPress (focus);
		}
	}
}
