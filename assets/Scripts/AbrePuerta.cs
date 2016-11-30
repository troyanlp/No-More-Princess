using UnityEngine;
using System.Collections;

public class AbrePuerta : MonoBehaviour {

    public bool open = false;

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


            if (!open)
            {
                GameObject door = GameObject.FindWithTag("BossDoor");
                door.transform.Translate(new Vector3(0f,1f,0f));
                open = true;
                //GameObject.FindWithTag("Midboss").GetComponent<BossLogic>().awakeBoss();
                //BossLogic scrpt = boss.GetComponent<BossLogic>.awakeBoss();
            }

        }
    }
}
