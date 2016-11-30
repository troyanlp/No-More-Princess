using UnityEngine;
using System.Collections;

public class hacha_izquierda : MonoBehaviour {

	public float angle = 90.0f;
	public Quaternion qStart, qEnd;
	public float speed = 1.5f;
	private float startTime;

	// Use this for initialization
	void Start () {
		qStart = Quaternion.AngleAxis (-angle, Vector3.right);
		qEnd = Quaternion.AngleAxis (angle, Vector3.right);
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("customRotate");
	}
	
	IEnumerator customRotate() {
		
		yield return new WaitForSeconds(2.0f);
		startTime += Time.deltaTime;
		transform.rotation = Quaternion.Lerp (qStart, qEnd,(Mathf.Sin(startTime * speed) + 1.0f)/ 2.0f);
		
		
	}
}
