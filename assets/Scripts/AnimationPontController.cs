using UnityEngine;
using System.Collections;

public class AnimationPontController : MonoBehaviour {

	public GameObject puente, trigger;
	private GameObject suelo;
	Animator animator;
	public GameObject pecesToHide;
	public bool pecesToHideBool = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		suelo = this.transform.parent.gameObject.transform.GetChild(1).gameObject;

		pecesToHide = GameObject.Find("peces");
	}
	
	// Update is called once per frame
	void Update () {
		/*if (pecesToHideBool == true) {
			foreach(Renderer pieces in GetComponentsInChildren<Renderer>()){
				pieces.material.color.a = Color(pieces.material.color.r,pieces.material.color.g,pieces.material.color.b,0.5f);
			}
		}*/ //Time.deltaTime
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "Player")
		{
			//execute corutine 
			StartCoroutine("WaitAndHidePeces");
		}
	}

	IEnumerator WaitAndHidePeces()
	{	
		yield return new WaitForSeconds(1.0f);
		animator.SetBool("activatePont",true);
		suelo.GetComponent<Collider> ().isTrigger = true;
		pecesToHideBool = true;
		// suspend execution for 4 seconds
		yield return new WaitForSeconds(1.8f);
		pecesToHide.SetActive (false);

	}

}
