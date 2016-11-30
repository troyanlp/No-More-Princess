using UnityEngine;
using System.Collections;

public class pinxos : MonoBehaviour {

	private bool control;
	public float pinxoTime;
	public float controlTime;
	// Use this for initialization
	void Start () {
		control = true;
		pinxoTime = Time.time;
		controlTime = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale >  0.0f)
        {
            this.transform.Translate(0, 0, (Mathf.Sin(Time.time*2)/25));
        }



    }
}
