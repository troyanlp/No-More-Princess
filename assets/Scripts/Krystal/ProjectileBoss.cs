using UnityEngine;
using System.Collections;

public class ProjectileBoss: MonoBehaviour {
	
	//Velocitat
	public float _velocitat;
    public GameObject particle;


    private Vector3 moveDir;

    // Use this for initialization
    void Start () {
        Vector3 P0 = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 P1 = transform.position;
        moveDir = P0 - P1;
        moveDir.Normalize();
    }
	
	// Update is called once per frame
	void Update () {
		
        // 

		float movement = _velocitat * Time.deltaTime;
		transform.Translate(moveDir * movement);

		Renderer r = GetComponent<Renderer>();
		if (!r.isVisible) {
			Destroy (gameObject);
		}
    }

    //Es crida automaticament quan hi ha una col·lisio entre dos GameObjects amb rigidbody
    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Player")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            otherObject.GetComponent<Birgin_Controller>().hurt(2);
            Destroy(gameObject);
        }

    }
}
