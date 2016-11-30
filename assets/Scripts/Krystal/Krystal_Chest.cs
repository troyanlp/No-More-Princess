using UnityEngine;
using System.Collections;

public class Krystal_Chest : MonoBehaviour {

    public FinalBossAction Krystal;

    private bool inv;
	// Use this for initialization
	void Start () {
        inv = true;
        GetComponentInChildren<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
    }

    void OnTriggerEnter(Collider other)
    {
        if (!inv)
        {
            if (other.tag == "Sword")
            {
                Krystal.hurt();
            }
        }
    }

    public void weakNotWeak()
    {
        inv = !inv;
        GetComponentInChildren<Renderer>().enabled = !GetComponentInChildren<Renderer>().enabled;
    }


}
