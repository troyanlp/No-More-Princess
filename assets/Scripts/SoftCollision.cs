using UnityEngine;
using System.Collections;

public class SoftCollision : MonoBehaviour {

    public int damage;
    public string tag;

	// Use this for initialization
	void Start () {
        tag = this.gameObject.tag;
        if (tag == "Guillotine")
        {
            damage = 50;
        }
        if (tag == "Enemy")
        {
            damage = 1;
        }
        if (tag == "Spikes" || tag == "Bichopincho")
        {
            damage = 2;
        }
        if (tag == "Guilloten")
        {
            damage = 2;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Aux");

            col.GetComponent<Birgin_Controller>().hurt(damage);
            if(tag == "Guillotine") col.GetComponent<Birgin_Controller>().hp = 0;

        }
    }
}
