using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MenuHUD : MonoBehaviour {

	private Birgin_Controller sirBirgin;
	public Text flechas;
	private Text vidas;
	public Image vidasImage;
	public Image potionImage;
	public Image keyImage;
	public Material keyMat;
	public Material potion;
	public Material potioff;
	public Material hearts3_0;
	public Material hearts3_05;
	public Material hearts3_1;
	public Material hearts3_15;
	public Material hearts3_2;
	public Material hearts3_25;
	public Material hearts3_3;
	public Material hearts4_0;
	public Material hearts4_05;
	public Material hearts4_1;
	public Material hearts4_15;
	public Material hearts4_2;
	public Material hearts4_25;
	public Material hearts4_3;
	public Material hearts4_35;
	public Material hearts4_4;
	public Material hearts5_0;
	public Material hearts5_05;
	public Material hearts5_1;
	public Material hearts5_15;
	public Material hearts5_2;
	public Material hearts5_25;
	public Material hearts5_3;
	public Material hearts5_35;
	public Material hearts5_4;
	public Material hearts5_45;
	public Material hearts5_5;
	public Material hearts6_0;
	public Material hearts6_05;
	public Material hearts6_1;
	public Material hearts6_15;
	public Material hearts6_2;
	public Material hearts6_25;
	public Material hearts6_3;
	public Material hearts6_35;
	public Material hearts6_4;
	public Material hearts6_45;
	public Material hearts6_5;
	public Material hearts6_55;
	public Material hearts6_6;
	private int numCors;
	private bool hasPotion;
	public bool hasKey;

	// Use this for initialization
	void Start () {
		
		//get sirBiring
		sirBirgin = GameObject.FindGameObjectWithTag("Player").GetComponent<Birgin_Controller>();

		//to delete
		//numCors = 4;
	}

	// Update is called once per frame
	void Update () {

		//arrow counter
		flechas.text = String.Format ("x{0}",sirBirgin.ammo.ToString());

		//potion manager
		if (sirBirgin.hasPotion == true) {
			potionImage.material = potion;
		} else {
			potionImage.material = potioff;
		}

		//Golden key manager
		if (sirBirgin.hasKey == true) {
			keyImage.enabled = true;
		} else {
			keyImage.enabled = false;
		}

		//Vidas i Cors manager
		switch(sirBirgin.numCors){
			case 3:
				switch((int)sirBirgin.hp){
					case 0:
						vidasImage.material = hearts3_0;
					break;
					case 1:
						vidasImage.material = hearts3_05;
                        //Debug.Log("hola");
					break;
					case 2:
						vidasImage.material = hearts3_1;
					break;
					case 3:
						vidasImage.material = hearts3_15;
					break;
					case 4:
						vidasImage.material = hearts3_2;
					break;
					case 5:
						vidasImage.material = hearts3_25;
					break;
					case 6:
						vidasImage.material = hearts3_3;
					break;
				}
			break;
			case 4:
				switch((int)sirBirgin.hp){
					case 0:
						vidasImage.material = hearts4_0;
					break;
					case 1:
						vidasImage.material = hearts4_05;
					break;
					case 2:
						vidasImage.material = hearts4_1;
					break;
					case 3:
						vidasImage.material = hearts4_15;
					break;
					case 4:
						vidasImage.material = hearts4_2;
					break;
					case 5:
						vidasImage.material = hearts4_25;
					break;
					case 6:
						vidasImage.material = hearts4_3;
					break;
					case 7:
						vidasImage.material = hearts4_35;
					break;
					case 8:
						vidasImage.material = hearts4_4;
					break;
				}
			break;
			case 5:
				switch((int)sirBirgin.hp){
					case 0:
						vidasImage.material = hearts5_0;
					break;
					case 1:
						vidasImage.material = hearts5_05;
					break;
					case 2:
						vidasImage.material = hearts5_1;
					break;
					case 3:
						vidasImage.material = hearts5_15;
					break;
					case 4:
						vidasImage.material = hearts5_2;
					break;
					case 5:
						vidasImage.material = hearts5_25;
					break;
					case 6:
						vidasImage.material = hearts5_3;
					break;
					case 7:
						vidasImage.material = hearts5_35;
					break;
					case 8:
						vidasImage.material = hearts5_4;
					break;
					case 9:
						vidasImage.material = hearts5_45;
					break;
					case 10:
						vidasImage.material = hearts5_5;
					break;
				}
			break;
			case 6:
				switch((int)sirBirgin.hp){
					case 0:
						vidasImage.material = hearts6_0;
					break;
					case 1:
						vidasImage.material = hearts6_05;
					break;
					case 2:
						vidasImage.material = hearts6_1;
					break;
					case 3:
						vidasImage.material = hearts6_15;
					break;
					case 4:
						vidasImage.material = hearts6_2;
					break;
					case 5:
						vidasImage.material = hearts6_25;
					break;
					case 6:
						vidasImage.material = hearts6_3;
					break;
					case 7:
						vidasImage.material = hearts6_35;
					break;
					case 8:
						vidasImage.material = hearts6_4;
					break;
					case 9:
						vidasImage.material = hearts6_45;
					break;
					case 10:
						vidasImage.material = hearts6_5;
					break;
					case 11:
						vidasImage.material = hearts6_55;
					break;
					case 12:
						vidasImage.material = hearts6_6;
					break;
				}
			break;
		}
	}
}
