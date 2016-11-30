using UnityEngine;
using System.Collections;

public class Barrera : MonoBehaviour {



	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void activate()
    {
        GetComponent<Renderer>().enabled = true;
        GetComponent<BoxCollider>().isTrigger = false;
    }
}
