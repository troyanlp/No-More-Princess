using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuExit : MonoBehaviour {
	
	public Canvas principalMenu;
	public Canvas ingameMenu;
	public Text yesText;
	public Text noText;
	public int focusExit;
	public Material exit_yes;
	public Material exit_no;
	public Color unselectedTextColor;
	public Color selectedTextColor;
	public Image exitImage;

	void Start () {

		unselectedTextColor = new Color(0.333F, 0.239F, 0.086F, 1);
		selectedTextColor = new Color(0.176F, 0.156F, 0.086F, 1);
		
		//Boton yesButton - Initial state: Unelected
		yesText = yesText.GetComponent<Text>();
		yesText.color = unselectedTextColor;

		//Boton noButton - Initial state: Selected
		noText = noText.GetComponent<Text>();
		noText.color = selectedTextColor;

		//focusExit manages button focusExit logic - initiate 0
		focusExit = 1;
	}

	public int MoveFocusUp(int focusExit) {

		if (focusExit == 1) {
			focusExit = 0;
		} 

		return focusExit;
	}

	public int MoveFocusDown(int focusExit) {

		if (focusExit == 0){
			focusExit = 1;
		}

		return focusExit;
	}

	void UpdateFocus(int focusExit){

		switch (focusExit) {
		case 0:
			exitImage.material = exit_yes;
			yesText.color = selectedTextColor;
			noText.color = unselectedTextColor;
			break;
		case 1:
			exitImage.material = exit_no;
			yesText.color = unselectedTextColor;
			noText.color = selectedTextColor;
			break;
		}
	}

	void EnterPress (int focusExit){

		switch(focusExit){
		case 0:
			//Check if exit is inGame or menuPrincipal
			if(SceneManager.GetActiveScene().name.Contains("Level") ) {
				SceneManager.LoadScene ("menu");
				Destroy(gameObject);
			} else {
				Application.Quit();	
			}

			break;
		case 1:
			//Check if exit is inGame or menuPrincipal
			if (SceneManager.GetActiveScene().name.Contains ("Level")) {
				//Debug.Log ("Sortim ingame");
				//ingameMenu.enabled = true;
				Instantiate(ingameMenu);
				Destroy (gameObject);
			} else {
				Instantiate (principalMenu);
				Destroy (gameObject);
			}
			break;
		}
	}

	void Update () {

		if (Input.GetKeyDown ("right")) {
			focusExit = MoveFocusDown (focusExit);
			//Repintar focusExit
			UpdateFocus(focusExit);
		}

		if (Input.GetKeyDown ("left")) {
			focusExit = MoveFocusUp (focusExit);
			//Repintar focusExit
			UpdateFocus(focusExit);
		}

		if(Input.GetKeyDown ("return")){
			EnterPress (focusExit);
		}
	}
}
