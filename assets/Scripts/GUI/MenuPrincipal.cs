
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;

public class MenuPrincipal : MonoBehaviour {

	public Canvas exitMenu;
	public Canvas controlsMenu;
	public Canvas levelsMenu;
	//public Canvas ingameMenu;
	public Button start;
	public Button level;
	public Button controls;
	public Button exit;
	public Text startText;
	public Text levelText;
	public Text controlsText;
	public Text exitText;
	public int focus;

	public Color unselectedBGColor;
	public Color selectedBGColor;
	public Color unselectedTextColor;
	public Color selectedTextColor;

	void Start () {

        Singleton.Instance.setZeroLevel();

		unselectedBGColor = new Color(0.529F, 0.407F, 0.239F, 1);
		selectedBGColor = new Color(0.364F, 0.305F, 0.227F, 1);
		unselectedTextColor = new Color(0.333F, 0.239F, 0.086F, 1);
		selectedTextColor = new Color(0.176F, 0.156F, 0.086F, 1);

		//Boton Iniciar Partida - Initial state: Selected
		start = start.GetComponent<Button> ();
		start.image.color = selectedBGColor;
		startText = startText.GetComponent<Text>();
		startText.color = selectedTextColor;

		//Boton Level Select - Initial state: Unselected
		level = level.GetComponent<Button> (); 
		level.image.color = unselectedBGColor;
		levelText = levelText.GetComponent<Text>();
		levelText.color = unselectedTextColor;

		//Boton Controles - Initial state: Unselected
		controls = controls.GetComponent<Button> ();
		controls.image.color = unselectedBGColor;
		controlsText = controlsText.GetComponent<Text>();
		controlsText.color = unselectedTextColor;

		//Boton Salida - Initial state: Unselected
		exit = exit.GetComponent<Button> ();
		exit.image.color = unselectedBGColor;
		exitText = exitText.GetComponent<Text>();
		exitText.color = unselectedTextColor;

		//focus manages button focus logic - initiate 0
		focus = 0;
	}

	//Mou el focus cap a dalt, resta un al comptador fins a 0
	public int MoveFocusUp(int focus) {

		if (focus != 0){
			focus = focus - 1;
		}

		return focus;
	}

	//Mou el focus cap abaix, suma un al comptador fins a 3
	public int MoveFocusDown(int focus) {

		if (focus != 3){
			focus = focus + 1;
		}

		return focus;
	}

	//Repintem el focus
	void UpdateFocus(int focus){

		switch (focus) {
		case 0:
			start.image.color = selectedBGColor;
			level.image.color = unselectedBGColor;
			controls.image.color = unselectedBGColor;
			exit.image.color = unselectedBGColor;

			startText.color = selectedTextColor;
			levelText.color = unselectedTextColor;
			controlsText.color = unselectedTextColor;
			exitText.color = unselectedTextColor;
			break;
		case 1:
			start.image.color = unselectedBGColor;
			level.image.color = selectedBGColor;
			controls.image.color = unselectedBGColor;
			exit.image.color = unselectedBGColor;

			startText.color = unselectedTextColor;
			levelText.color = selectedTextColor;
			controlsText.color = unselectedTextColor;
			exitText.color = unselectedTextColor;
			break;
		case 2:
			start.image.color = unselectedBGColor;
			level.image.color = unselectedBGColor;
			controls.image.color = selectedBGColor;
			exit.image.color = unselectedBGColor;

			startText.color = unselectedTextColor;
			levelText.color = unselectedTextColor;
			controlsText.color = selectedTextColor;
			exitText.color = unselectedTextColor;
			break;
		case 3:
			start.image.color = unselectedBGColor;
			level.image.color = unselectedBGColor;
			controls.image.color = unselectedBGColor;
			exit.image.color = selectedBGColor;

			startText.color = unselectedTextColor;
			levelText.color = unselectedTextColor;
			controlsText.color = unselectedTextColor;
			exitText.color = selectedTextColor;
			break;
		}
	}

	//Quan apretem enter, seleccionem un item del menu
	/*
		0: Nivell 1
		1: Seleccionar nivell
		2: Controls
		3: Exit
	*/
	void EnterPress (int focus){

		switch(focus){
		case 0:
            Singleton.Instance.setNewGame();
			SceneManager.LoadScene ("Level 1");
			break;
		case 1:
			Instantiate (levelsMenu);
			Destroy(gameObject);
			break;
		case 2:
			Instantiate (controlsMenu);
			Destroy(gameObject);
			break;
		case 3:
			Instantiate (exitMenu);
			Destroy(gameObject);
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
