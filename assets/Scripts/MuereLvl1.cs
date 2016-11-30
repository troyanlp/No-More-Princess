using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MuereLvl1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Birgin_Controller>().inv = false;
            col.GetComponent<Birgin_Controller>().hurt(70);
        }
        
    }

}
