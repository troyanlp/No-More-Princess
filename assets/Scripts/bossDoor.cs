using UnityEngine;
using System.Collections;

public class bossDoor : MonoBehaviour {

    public bool opened = false; 

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            Singleton.Instance.print();


        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && opened )
        {
            Debug.Log("Abrete!");
            Singleton.Instance.nextLevel();
        }
    }

}
