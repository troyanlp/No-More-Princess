using UnityEngine;
using System.Collections;

public class lanzaLaser : MonoBehaviour {

    private int count = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && count == 0)
        {
            //CharacterController control = col.GetComponent<CharacterController>();
            //control.SimpleMove( new Vector3(0f,30f,0f) );

            //Debug.Log(col.tag);

            GameObject[] g = GameObject.FindGameObjectsWithTag("Barrera");
            g[0].GetComponent<Barrera>().activate();
            g[1].GetComponent<Barrera>().activate();
            count = 1;
        }
    }

}
