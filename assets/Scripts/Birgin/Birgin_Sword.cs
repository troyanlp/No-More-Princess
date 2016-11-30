using UnityEngine;
using System.Collections;

public class Birgin_Sword : MonoBehaviour {

    private Birgin_Controller Birgin;

	// Use this for initialization
	void Start () {
        Birgin = GameObject.FindGameObjectWithTag("Player").GetComponent<Birgin_Controller>();
    }
	
	// Update is called once per frame
	void Update () {

    }

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
            /*if (otherObject.tag == "FinalBoss")
            {
                otherObject.GetComponent<FinalBossAction>().hurt();
            }*/

        }

    }

}
