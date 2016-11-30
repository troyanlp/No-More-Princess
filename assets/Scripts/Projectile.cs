using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	//Velocitat
	public float _velocitat;
    private float bornTime;

    // Use this for initialization
    void Start () {
        bornTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		
        // 

		float movement = _velocitat * Time.deltaTime;
		transform.Translate(Vector3.left * movement);

        if (Time.time - bornTime >= 3f)
        {
            Destroy(this.gameObject);
        }
        
        //Si el projectil esta fora de pantalla el destruim
        /*Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider>().bounds))
        {
            Destroy(gameObject);
        }*/
    }

    //Es crida automaticament quan hi ha una col·lisio entre dos GameObjects amb rigidbody
    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Midboss")
        {
            //Destroy(otherObject.gameObject);
            otherObject.GetComponent<BossAction>().hurt();
            Destroy(this.gameObject);
        }

        if (otherObject.tag == "Enemy")
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }

        //Si és el player
        if (otherObject.tag != "Player" && otherObject.tag != "Finish" )
        {
            Destroy(this.gameObject);
            
        }

        

    }
}
