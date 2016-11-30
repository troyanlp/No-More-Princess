using UnityEngine;
using System.Collections;

public class bichopincho : MonoBehaviour {

	public GameObject StartPoint,EndPoint;
	private float journeyLength;
	private float speed = 3.0F;
	private float startTime;
	public bool fl = true;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
        /*for (int i = 0; i < this.gameObject.transform.childCount - 1; i++)
        {
            if (this.gameObject.transform.GetChild(i).transform.tag == "StartPoint")
            {
                StartPoint = this.gameObject.transform.GetChild(i).gameObject;
            }
            if (this.gameObject.transform.GetChild(i).transform.tag == "EndPoint")
            {
                EndPoint = this.gameObject.transform.GetChild(i).gameObject;
            }
        }*/
        journeyLength = Vector3.Distance(StartPoint.transform.position, EndPoint.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		if (fracJourney > 0.5f) { fl = true; }

		transform.position = Vector3.Lerp(StartPoint.transform.position, EndPoint.transform.position, fracJourney);

		if (fracJourney >= 1.0f && fl == true) {
			fl = false;
			fracJourney = 0;
			EndPoint.transform.position = StartPoint.transform.position;
			StartPoint.transform.position = this.transform.position;
			startTime = Time.time;
		}
	}
}
