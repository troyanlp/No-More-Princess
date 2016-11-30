using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuControles : MonoBehaviour {

	public Canvas principalMenu;
	public Canvas ingameMenu;
	public Canvas controlsMenu;
	public Button volverButton;
	public Text volverText;
	public Color selectedBGColor;
	public Color selectedTextColor;

	// Use this for initialization
	void Start () {

		selectedBGColor = new Color(0.364F, 0.305F, 0.227F, 1);
		selectedTextColor = new Color(0.176F, 0.156F, 0.086F, 1);

		volverButton = volverButton.GetComponent<Button> (); 
		volverButton.image.color = selectedBGColor;
		volverText = volverText.GetComponent<Text>();
		volverText.color = selectedTextColor;
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown ("return")){
			if (Singleton.Instance.getActualLevel() > 0) {
				Instantiate (ingameMenu);
				Destroy (gameObject);
			} else {
				Instantiate (principalMenu);
				Destroy (gameObject);
			}
		}
	}
}
