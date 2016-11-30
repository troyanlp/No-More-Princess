using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;
//using UnityEditor.SceneManagement;

public class MenuIngame : MonoBehaviour {

	public GameObject ingameMenu;
	public GameObject controlsMenu;
	public GameObject exitMenu;

	public Button continueButton;
	public Button controlsButton;
	public Button exitButton;
	public Text continueText;
	public Text controlsText;
	public Text exitText;
	public Color unselectedBGColor;
	public Color selectedBGColor;
	public Color unselectedTextColor;
	public Color selectedTextColor;
	private int focus;
	private bool isPaused;
	private Birgin_Controller sirBirgin;
	private Animator anim;
	private CharacterController controller;

	public GameObject[] allObjects;
	public GameObject[] enemies;
	public GameObject go;

	void Start () {

		Time.timeScale = 0.0F;

		unselectedBGColor = new Color(0.529F, 0.407F, 0.239F, 1);
		selectedBGColor = new Color(0.364F, 0.305F, 0.227F, 1);
		unselectedTextColor = new Color(0.333F, 0.239F, 0.086F, 1);
		selectedTextColor = new Color(0.176F, 0.156F, 0.086F, 1);
		
		//Boton Continuar Partida - Initial state: Selected
		continueButton = continueButton.GetComponent<Button> ();
		continueButton.image.color = selectedBGColor;
		continueText = continueText.GetComponent<Text>();
		continueText.color = selectedTextColor;

		//Boton Options - Initial state: Unselected
		controlsButton = controlsButton.GetComponent<Button> (); 
		controlsButton.image.color = unselectedBGColor;
		controlsText = controlsText.GetComponent<Text>();
		controlsText.color = unselectedTextColor;

		//Boton Salida - Initial state: Unselected
		exitButton = exitButton.GetComponent<Button> (); 
		exitButton.image.color = unselectedBGColor;
		exitText = exitText.GetComponent<Text>();
		exitText.color = unselectedTextColor;

		//focus manages button focus logic - initiate 0
		focus = 0;

		//isPaused initial state = false --> manages IngameMenu condition
		isPaused = false;

		//get sirBiring
		sirBirgin = GameObject.Find("Birgin").GetComponent<Birgin_Controller>();
		anim = GameObject.Find("Birgin").GetComponent<Animator>();
		controller = GameObject.Find("Birgin").GetComponent<CharacterController>();
		//enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		//enemiesAnim = enemies.GetComponent<Animation>();

		//sirBirgin.hp;
		//sirBirgin.ammo;

		//Get all GameObjects
		/*GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		foreach (GameObject go in allObjects) {
			if (go.activeInHierarchy) {
				Debug.Log (go + " is an active object");			
			}
		}*/
	}

	//Mou el focus cap a dalt, resta un al comptador fins a 0
	public int MoveFocusUp(int focus) {

		if (focus != 0){
			focus = focus - 1;
		}

		return focus;
	}

	//Mou el focus cap abaix, suma un al comptador fins a 2
	public int MoveFocusDown(int focus) {

		if (focus != 2){
			focus = focus + 1;
		}

		return focus;
	}

	//Repintem el focus
	void UpdateFocus(int focus){

		switch (focus) {
		case 0:
			continueButton.image.color = selectedBGColor;
			controlsButton.image.color = unselectedBGColor;
			exitButton.image.color = unselectedBGColor;

			continueText.color = selectedTextColor;
			controlsText.color = unselectedTextColor;
			exitText.color = unselectedTextColor;
			break;
		case 1:
			continueButton.image.color = unselectedBGColor;
			controlsButton.image.color = selectedBGColor;
			exitButton.image.color = unselectedBGColor;

			continueText.color = unselectedTextColor;
			controlsText.color = selectedTextColor;
			exitText.color = unselectedTextColor;
			break;
		case 2:
			continueButton.image.color = unselectedBGColor;
			controlsButton.image.color = unselectedBGColor;
			exitButton.image.color = selectedBGColor;

			continueText.color = unselectedTextColor;
			controlsText.color = unselectedTextColor;
			exitText.color = selectedTextColor;
			break;
		}
	}

	//Quan apretem enter, seleccionem un item del menu
	/*
		0: Continuar Partida
		1: Controles
		2: Exit
	*/
	void EnterPress (int focus){

		switch(focus){
		case 0:
			Time.timeScale = 1.0F;
			Destroy (ingameMenu);
			break;
		case 1:
			Instantiate (controlsMenu);
			Destroy (ingameMenu);
			break;
		case 2:
			Instantiate (exitMenu);
			Destroy (ingameMenu);
			break;
		}
	}

	public void pauseObjects() {
		
	}

	public void unPauseObjects() {

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

		if(Input.GetKeyDown(KeyCode.P)){
			Time.timeScale = 1.0F;
			Destroy (ingameMenu);
		}

		/*if (Input.GetKeyDown(KeyCode.P) ) {
			switch(isPaused){
				case true:
					//despausar tots els gameobjects actuals
					sirBirgin.enabled = true;
					anim.enabled = true;
					controller.enabled = true;
					break;
				case false:
					//pausar tots els gameobjects actuals
					sirBirgin.enabled = false;
					anim.enabled = false;
					controller.enabled = false;
				break;
			}
		}*/

		/*if(isPaused == true){
			//Funcio PauseObjects
			sirBirgin.enabled = false;
			anim.enabled = false;
			controller.enabled = false;
		}
		if(isPaused == false){
			//Funcio unpauseObjects
			sirBirgin.enabled = true;
			anim.enabled = true;
			controller.enabled = true;
		}*/
	}
}
