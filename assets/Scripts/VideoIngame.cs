using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class VideoIngame : MonoBehaviour {

	public GameObject video;
	public GameObject video1_detector;
	public GameObject video2_detector;
	public GameObject video3_detector;
	public MovieTexture video2_mig;
	public MovieTexture video3_mig;
	public MovieTexture video3_final;
	public GameObject HUD;
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;

    private AudioSource audioJuego;

	private MovieTexture auxVideo;
	//private AudioSource auxAudio;

	private GameObject video_final;
	private AudioSource audio_final;

    //private GameObject video;
	public bool active;

	// Use this for initialization
	void Start () {
		active = false;
    }
	
	// Update is called once per frame
	void Update () {

    }
		
	void OnTriggerEnter(Collider otherObject)
	{
        if (this.tag == "video1" && active == false)
		{
            Singleton.Instance.isVideogame = true;
            if (GameObject.FindGameObjectWithTag("audioGame")) {
                GameObject.FindGameObjectWithTag("audioGame").GetComponent<AudioSource>().Pause();
            }
			
            GameObject.FindGameObjectWithTag ("HUD").GetComponent<Canvas>().enabled = false;	
			
			video_final = Instantiate (video);
		    audio_final = Instantiate (audio1);

            auxVideo = video2_mig;
			video_final.GetComponentInChildren<RawImage> ().texture = auxVideo as MovieTexture;
			auxVideo.Play ();
			audio_final.Play ();
			//StartCoroutine (StopVideo());

			Time.timeScale = 0.0f;
            //Activar MidBoss
            GameObject.Find("Krystal_MidBoss").GetComponent<MidBossLogic>().awakeBoss();

            
        }
		if (this.tag == "video2" && !active)
		{
            Singleton.Instance.isVideogame = true;
            if (GameObject.FindGameObjectWithTag("audioGame"))
            {
                GameObject.FindGameObjectWithTag("audioGame").GetComponent<AudioSource>().Pause();
            }
            GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>().enabled = false;

			video_final = Instantiate(video);
			audio_final = Instantiate (audio2);

            auxVideo = video3_mig;
			video_final.GetComponentInChildren<RawImage> ().texture = auxVideo as MovieTexture;
			auxVideo.Play ();
			audio_final.Play ();
			//StartCoroutine (StopVideo());

			Time.timeScale = 0.0f;
            //Activar MidBoss
            GameObject.Find("Krystal_Boss").GetComponent<BossLogic>().awakeBoss();
            
        } 
		if (this.tag == "video3" && active == false)
		{
            Singleton.Instance.isVideogame = true;
            if (GameObject.FindGameObjectWithTag("audioGame"))
            {
                GameObject.FindGameObjectWithTag("audioGame").GetComponent<AudioSource>().Pause();
            }
            GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>().enabled = false;

			video_final = Instantiate (video);
			audio_final = Instantiate (audio3);

            auxVideo = video3_final;
			video_final.GetComponentInChildren<RawImage> ().texture = auxVideo as MovieTexture;
			auxVideo.Play ();
            Singleton.Instance.final = true;
			audio_final.Play ();
			//StartCoroutine (StopVideo());

			Time.timeScale = 0.0f;
        } 
		Destroy (gameObject);
	}


}