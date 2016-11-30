using UnityEngine;
using System.Collections;

public class BeamRay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroySprite());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Player")
        {
            otherObject.GetComponent<Birgin_Controller>().hurt(2);
        }

    }

    IEnumerator DestroySprite()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
