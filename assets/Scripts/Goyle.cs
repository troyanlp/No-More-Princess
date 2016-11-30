using UnityEngine;
using System.Collections;

public class Goyle : MonoBehaviour {
    public int movementspeed = 100;
    public float speed = 0.01f;
    public float _jumpSpeed;
    public float _gravity;
    public float amplitude = 0.1f;
    public float frequency = 1f;
    public CharacterController controller;

    public bool knockPlayer;

    //Enemy attributes
    public float life = 1f;
    public float attack = 0.5f;

    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        GameObject Player = GameObject.Find("Player");
        //knockPlayer = Player.GetComponent<Sir_Birgin_Controller>().knock;
    }
	
	// Update is called once per frame
	void Update () {

        transform.position += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.up;

    }

    public void arrowImpact()
    {
        life -= 10;
        if (life <= 0) Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            //CharacterController control = col.GetComponent<CharacterController>();
            //control.SimpleMove( new Vector3(0f,30f,0f) );

            //Debug.Log(col.tag);

          /*  if (col.GetComponent<Birgin_Controller>().hit)
            {
                //col.GetComponent<Birgin_Controller>().knockback(this.transform.position);
                col.GetComponent<Birgin_Controller>().hurt(1);
            }*/

        }

    }

}
