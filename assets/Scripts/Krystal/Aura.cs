using UnityEngine;
using System.Collections;

public class Aura : MonoBehaviour {

	// Variables de control de temps
	private float actualTime;
	private float prevTime;

	// Use this for initialization
	void Start () {
		actualTime = Time.time;
		prevTime = Time.time;
	}

	// Update is called once per frame
	void Update () {

		actualTime = Time.time;
        if (actualTime - prevTime > 2)
        {
            transform.localScale = transform.localScale - new Vector3(0.1f,0.1f,0.1f);
        }
        if (actualTime - prevTime > 2.5)
		{
			Destroy (gameObject);
		}
	}

}
