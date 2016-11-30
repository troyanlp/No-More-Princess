using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class videomanager : MonoBehaviour {

	private MovieTexture auxVideo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag ("VideoIngame") != null){

            if (Singleton.Instance.final)
            {
                SceneManager.LoadScene("menu");
                Singleton.Instance.save();
                Singleton.Instance.final = false;
            }

            GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>().enabled = true;

			Time.timeScale = 1.0F;

			//GameObject.Find ("VideoIngame").GetComponentInChildren<RawImage> ().texture = auxVideo as MovieTexture;
			//auxVideo.Stop ();
			Destroy(GameObject.FindGameObjectWithTag ("VideoIngame"));
			//Destroy(GameObject.FindGameObjectWithTag ("audio"));

            

        }
		if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag ("AudioIntro") != null){
			Destroy(GameObject.FindGameObjectWithTag ("AudioIntro"));
		}

        if (Input.GetKeyDown(KeyCode.Escape) && Singleton.Instance.isVideogame) {
            GameObject.FindGameObjectWithTag("audioGame").GetComponent<AudioSource>().Play();
            Singleton.Instance.isVideogame = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("audio") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("audio"));
        }


        /*	
		if(GameObject.FindGameObjectWithTag ("audio1") != null && GameObject.FindGameObjectWithTag ("AudioIngame") != null ){
			GameObject.FindGameObjectWithTag ("audio1").GetComponent<AudioSource>().
		}
		if(GameObject.FindGameObjectWithTag ("audio2") != null && GameObject.FindGameObjectWithTag ("AudioIngame") != null){
			Destroy (GameObject.FindGameObjectWithTag ("audio2"));
		}
		if(GameObject.FindGameObjectWithTag ("audio3") != null && GameObject.FindGameObjectWithTag ("AudioIngame") != null){
			Destroy (GameObject.FindGameObjectWithTag ("audio3"));
		}*/
    }
}
