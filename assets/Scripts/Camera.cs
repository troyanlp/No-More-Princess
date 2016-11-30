using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
    public int movementspeed = 100;
    public float speed = 1f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //float hor = Input.GetAxis("Horizontal");
        //transform.Translate(hor * speed, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.5f * speed, 0.0f, 0.0f);
        }
        // Funcio que es cridara quan sigui l'atac de dispar
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0.5f * -1*speed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0.0f,  0.1f * speed, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0.0f, 0.1f * -1 * speed, 0.0f);
        }

    }
}
