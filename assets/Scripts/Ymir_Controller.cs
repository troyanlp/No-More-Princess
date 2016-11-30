using UnityEngine;
using System.Collections;

public class Ymir_Controller : MonoBehaviour
{

    public int movementspeed = 100;
    public float speed = 0.1f;
    public float _gravity;
    public CharacterController controller;
    private Animator anim;
    public float hp = 3;

    public bool right = false;
    public bool left = true;

    private float actualTime;
    private float prevTime;
    public float randTime = 2.0f;

    private int moveX = 0;

    public bool EnemyActive = true;

    private Vector3 auxPosition;



    //Enemy attributes
    public int attack = 1;

    public bool atack = false;


    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0F;

    public float deathTimer = 0f;

    //Sir Birgin
    private GameObject pj;


	public int before = 0; // 0 = left, 1 = right;

    //public ymirDistance = ;
    //public fridgerdDistance = ;



    // Use this for initialization
    void Start()
    {

		if (this.tag == "Fridgerd") {
			    transform.Rotate (new Vector3 (0, 180, 0));
		}


        anim = GetComponent<Animator>();
        ruta_de_vigilancia();
        anim.SetBool("atack", false);
        anim.SetBool("walk_bool", false);

        pj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(atack);

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

        if (deathTimer >= 11f)
        {
            Destroy(this.gameObject);
        }
        //Si esta mas cerca de 100 
        float distance = Mathf.Sqrt(Mathf.Pow(pj.transform.position.x - transform.position.x, 2) + Mathf.Pow(pj.transform.position.y - transform.position.y, 2));
        if (distance < 10 && this.tag != "PapaYmir" || this.tag == "PapaYmir" && distance < 20)
        {
            //Y más cerca de 5
            
			if (distance < 2.6 && this.tag == "Ymir" || distance < 1.5 && this.tag == "Fridgerd" || distance < 7.5 && this.tag == "PapaYmir") 
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

	void movimiento () {

        
		Vector3 VectorHaciaObjetivo = pj.transform.position - transform.position;
		VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, 0, VectorHaciaObjetivo.z);

		VectorHaciaObjetivo.Normalize();
		if (this.tag == "Fridgerd") {
			VectorHaciaObjetivo *= 2;
		}
		VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, 
			VectorHaciaObjetivo.y, 
			VectorHaciaObjetivo.z);

		if(EnemyActive) transform.Translate(VectorHaciaObjetivo * Time.deltaTime*1.5f, Space.World);


        atack = false;
        

        //lOS ENEMIGOS AGENTES DE LA NAVMESH
        // El movimiento en vez de un translate usar navigation (o la funcion que use el navmesh)

    }

    void ruta_de_vigilancia()
    {
        //El enemigo esta vigilando
        //Debug.Log("Estoy vigilando");
        //anim.Play("Ymir idle", -1, 0f);
        anim.SetBool("idle", true);
        anim.SetBool("walk_bool", false);
        anim.SetBool("atack", false);

        atack = false;
    }


    void perseguir()
    {
        //El enemigo persigue al personaje
        //Debug.Log("Estoy persiguiendo");
        anim.SetBool("walk_bool",true);
        anim.SetBool("atack", false);
        anim.SetBool("idle", false);
        //StartCoroutine(WaitAndAttack(2f));
        //anim.Play("Ymir Walk",-1,0f);

        atack = false;
    }

    void golpear()
    {
        //El enemigo golpea al personaje
        //Debug.Log("Estoy golpeando");
        anim.SetBool("idle", false);
        anim.SetBool("atack", true);
        //StartCoroutine(WaitAndAttack(2f));
        anim.SetBool("walk_bool", false);
        //Debug.Log(anim.GetBool("attack"));
        //anim.Play("Ymir Atac", -1, 0f);
        //yield return new WaitForSeconds(1.0f);

        atack = true;
    }

    public void endAttack()
    {
        atack = false;
        anim.SetBool("atack", false);
        anim.SetBool("idle", true);
        anim.SetBool("walk_bool", false);
    }

    public void desaparece()
    {
        Debug.Log("Desaparece");
        Destroy(this.gameObject);
    }

    IEnumerator WaitAndAttack(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        //anim.Play("Ymir Atac", -1, 0f);
        anim.SetBool("atack", false);
        atack = false;
    }

    IEnumerator WaitAndWalk(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        //anim.Play("Ymir Atac", -1, 0f);
    }

    public void hurt()
    {
        Debug.Log("Aux");
        if (EnemyActive)
        {
            hp--;
			if (this.tag == "Fridgerd") {
				anim.Play ("Fridgerd Hit", -1, 0f);
			}
			if (this.tag == "Ymir") {
				anim.Play ("Hurt", -1, 0f);
			}
        }

    }

    public void die()
    {
        if (EnemyActive)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            Debug.Log("ooooooo");
			if (this.tag == "Fridgerd") {
				anim.Play ("Fridgerd Die", -1, 0f);
			}
			if (this.tag == "Ymir") {
				anim.Play ("Death", -1, 0f);

			}
            EnemyActive = false;
            
        }

    }

    
	void OnTriggerEnter(Collider otherObject)
	{
        //Debug.Log(otherObject.tag);
		if (otherObject.tag == "Player" && atack && EnemyActive)
		{
			Debug.Log(otherObject.tag);
            otherObject.GetComponent<Birgin_Controller>().hurt(attack);
		}
	}
    
}