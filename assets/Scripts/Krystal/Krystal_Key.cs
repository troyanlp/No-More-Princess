using UnityEngine;
using System.Collections;

public class Krystal_Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Birgin_Controller>().hasKey = true;
            GameObject.FindGameObjectWithTag("BossDoor").GetComponent<bossDoor>().opened = true;
            Destroy(gameObject);
        }

    }
}
