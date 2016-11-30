using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[RequireComponent (typeof(AudioSource))]

public class VideoIntro : MonoBehaviour {

	public MovieTexture video1;
	public MovieTexture video2;
	public MovieTexture video3;
	public GameObject HUD;
	private MovieTexture video_aux;
	private AudioSource audio_final;
	public AudioSource audio1Intro;
	public AudioSource audio2Intro;
	public AudioSource audio3Intro;
	public AudioSource audio1Game;
	public AudioSource audio2Game;
	public AudioSource audio3Game;

	// Use this for initialization
	void Start () {
		//pause scene objects
		Time.timeScale = 0.0f;

		//Select intro video switch scene
		if(SceneManager.GetActiveScene().name.Contains("Level 1") ){
			video_aux = video1;
			GetComponentInChildren<RawImage> ().texture = video_aux as MovieTexture;
			video_aux.Play ();
			audio_final = Instantiate (audio1Intro);
			//StartCoroutine (StopVideo());
		}
		if(SceneManager.GetActiveScene().name.Contains("Level 2") ){
			video_aux = video2;
			GetComponentInChildren<RawImage> ().texture = video_aux as MovieTexture;
			video_aux.Play ();
			audio_final = Instantiate (audio2Intro);
			//StartCoroutine (StopVideo());
		}
		if(SceneManager.GetActiveScene().name.Contains("Level 3") ){
			video_aux = video3;
			GetComponentInChildren<RawImage> ().texture = video_aux as MovieTexture;
			video_aux.Play ();
			audio_final = Instantiate (audio3Intro);
			//StartCoroutine (StopVideo());
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)){
			video_aux.Stop ();
			audio_final.Stop ();

			Time.timeScale = 1.0F;

			Instantiate (HUD);

			if(SceneManager.GetActiveScene().name.Contains("Level 1") ){
                audio1Intro.Pause();
                Instantiate (audio1Game);
			}
			if(SceneManager.GetActiveScene().name.Contains("Level 2") ){
                audio2Intro.Pause();
				Instantiate (audio2Game);
			}
			if(SceneManager.GetActiveScene().name.Contains("Level 3") ){
                audio3Intro.Pause();
                Instantiate (audio3Game);
			}
            Destroy(gameObject);
        }
	}

	IEnumerator StopVideo(){
		while (audio_final.isPlaying) {

		}

		if(SceneManager.GetActiveScene().name.Contains("Level 3") ){
			SceneManager.LoadScene ("menu");
		}


		yield return new WaitForSeconds(0.1f);
	}
}