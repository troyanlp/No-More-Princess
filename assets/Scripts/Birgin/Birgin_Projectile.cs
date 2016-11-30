using UnityEngine;
using System.Collections;

public class Birgin_Projectile : MonoBehaviour {
	
	//Velocitat
	private float speed;
    private Birgin_Controller Birgin;

    // Use this for initialization
    void Start () {
        speed = 20;
        Birgin = GameObject.Find("Birgin").GetComponent<Birgin_Controller>();
    }
	
	// Update is called once per frame
	void Update () {
		
        // 

		float movement = speed * Time.deltaTime;
		transform.Translate(Vector3.right * movement);

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
        if (Birgin.isAttacking())
        {

            if (otherObject.tag == "Ymir")
            {
                otherObject.GetComponent<Ymir_Controller>().hurt();
            }
            if (otherObject.tag == "PapaYmir")
            {
                otherObject.GetComponent<Ymir_Controller>().hurt();
            }
            if (otherObject.tag == "Fridgerd")
            {
                otherObject.GetComponent<Ymir_Controller>().hurt();
            }
            if (otherObject.tag == "MidBoss")
            {
                otherObject.GetComponent<MidBossAction>().hurt();
            }
            if (otherObject.tag == "Boss")
            {
                otherObject.GetComponent<BossAction>().hurt();
            }
            if (otherObject.tag == "FinalBoss")
            {
                otherObject.GetComponent<FinalBossAction>().hurt();
            }
        }
    }
}
