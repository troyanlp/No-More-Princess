using UnityEngine;
using System.Collections;

public class HardCollision : MonoBehaviour {

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
            //CharacterController control = col.GetComponent<CharacterController>();
            //control.SimpleMove( new Vector3(0f,30f,0f) );

            //Debug.Log(col.tag);

            /*if (col.GetComponent<Sir_Birgin_Controller>().knock)
            {
                col.GetComponent<Sir_Birgin_Controller>().knockback(this.transform.position);
                col.GetComponent<Sir_Birgin_Controller>().hurt(0.5f);
            }*/

        }
    }

}
