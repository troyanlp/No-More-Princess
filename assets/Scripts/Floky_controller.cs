using UnityEngine;
using System.Collections;

public class Floky_controller : MonoBehaviour {

	private Animator anim;

	public bool right = false;
	public bool left = true;

	public float hp = 3;

	//Sir Birgin
	public GameObject pj;

	public bool EnemyActive = true;
	private bool atack = false;

	public float deathTimer = 0f;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator>();
		ruta_de_vigilancia();
		anim.SetBool("atack", false);
		anim.SetBool("walk_bool", false);

	}
	
	// Update is called once per frame
	void Update () {


		if (pj.transform.position.x - transform.position.x > 0) {

			if (right == true) {
				transform.Rotate (new Vector3 (0, 180, 0));
			}
			right = false;
			left = true;
		} else {
			if (left == true) {
				transform.Rotate (new Vector3 (0, 180, 0));
			}
			right = true;
			left = false;
		}

		if (hp <= 0)
		{
			if (EnemyActive) die();
			deathTimer += 0.1f;
		}

		if (deathTimer >= 12f)
		{
			Destroy(this.gameObject);
		}
		//Si esta mas cerca de 100 
		if (Mathf.Abs(pj.transform.position.x - transform.position.x) < 10)
		{
			//Y más cerca de 5
			if (Mathf.Abs(pj.transform.position.x - transform.position.x) < 4.5) 
			{
				golpear();

				//Debug.Log(pj.transform.position.x - transform.position.x);
			}
			else
			{
				if (!atack)
				{

					movimiento();
				}
				perseguir();

			}
		}
		else
		{
			ruta_de_vigilancia();
		}
	}

	void ruta_de_vigilancia()
	{

		anim.SetBool("idle", true);
		anim.SetBool("walk", false);
		anim.SetBool("atack", false);

		atack = false;
	}

	public void die()
	{
		if (EnemyActive)
		{
			if (this.tag == "Floky") {
				//anim.Play ("Floky Die", -1, 0f);
			}
			if (this.tag == "PapaFloky") {
				anim.Play ("Death", -1, 0f);

			}
			EnemyActive = false;
		}

	}

	void golpear()
	{
		//El enemigo golpea al personaje
		anim.SetBool("idle", false);
		anim.SetBool("atack", true);
		anim.SetBool("walk", false);


		atack = true;
	}

	void movimiento () {

		Vector3 VectorHaciaObjetivo = pj.transform.position - transform.position;
		VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, 0, VectorHaciaObjetivo.z);

		VectorHaciaObjetivo.Normalize();
		if (this.tag == "Floky") {
			VectorHaciaObjetivo *= 3;
		}
		VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, 
			VectorHaciaObjetivo.y, 
			VectorHaciaObjetivo.z);

		transform.Translate(VectorHaciaObjetivo * Time.deltaTime*1.5f, Space.World);
		atack = false;

	}

	void perseguir()
	{

		anim.SetBool("walk",true);
		anim.SetBool("atack", false);
		anim.SetBool("idle", false);


		atack = false;
	}
}
