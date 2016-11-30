using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambiaNivel : MonoBehaviour {
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            Singleton.Instance.print();


        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            Singleton.Instance.load();
            Singleton.Instance.print();


        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            /*if(SceneManager.GetActiveScene().name.Contains("Level 1")){
				SceneManager.LoadScene(2);
			}
			if(SceneManager.GetActiveScene().name.Contains("Level 2")){
				SceneManager.LoadScene(3);
			}*/
            //Singleton.Instance.save(GameObject.FindGameObjectWithTag("Player").GetComponent<Birgin_Controller>().hp);
            Singleton.Instance.nextLevel();
        }
    }
}
