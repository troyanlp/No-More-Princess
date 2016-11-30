using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Birgin_Controller SirBirgin;
	private Canvas gameOver;

	// Use this for initialization
	void Start () {
        SirBirgin = GameObject.FindGameObjectWithTag("Player").GetComponent<Birgin_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		if (SirBirgin.hp <= 0) {
			gameOver = GetComponent<Canvas> ();
			gameOver.enabled = true;

			if (Input.GetKeyDown(KeyCode.Escape)){
				SceneManager.LoadScene ("menu");
			}
			if (Input.GetKeyDown(KeyCode.R)){
				//Select intro video switch scene
				if(SceneManager.GetActiveScene().name.Contains("Level 1") ){
					SceneManager.LoadScene ("Level 1");
				}
				if(SceneManager.GetActiveScene().name.Contains("Level 2") ){
					SceneManager.LoadScene ("Level 2");
				}
				if(SceneManager.GetActiveScene().name.Contains("Level 3") ){
					SceneManager.LoadScene ("Level 3");
				}
			}
		}
	}
}
