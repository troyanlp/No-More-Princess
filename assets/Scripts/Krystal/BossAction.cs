using UnityEngine;
using System.Collections;

public class BossAction : MonoBehaviour
{
    public float speed = 6.0F;
    public float gravity = 2.0F;
    public float hp = 3;

    public GameObject _projectile;
    public GameObject _beam;
	public GameObject _tp;

    public GameObject phaseBoss;

    // Flags de control del Boss
	private bool lookL, lookR, hit, action, dead;
	private int moveX = 0;
	private int tp_int = 0;
    private bool marker = false;
    private int numProj = 0;

	private CharacterController controller;
	private Vector3 moveDirection;
	private Animator anim;

    // Use this for initialization
    void Start()
    {
		lookR = false;
		lookL = true;
		hit = false;
		action = false;
		dead = false;

        anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();

		moveDirection = new Vector3(0, 0, 0);

        this.enabled = false;
    }

    // Update is called once per frame

    void Update()
    {
        
		if (!hit && !dead)
		{
			if (controller.isGrounded)
			{
                moveDirection.y -= 0;
            }

			moveDirection.x = moveX * speed;

			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
		}

		anim.SetInteger ("moveX", moveX);
		anim.SetBool("action", action);
		anim.SetBool("hit", hit);
		//anim.SetBool("grounded", controller.isGrounded);
	}

    public void DoAction(int n)
    {
        if (!dead)
        {
			action = true;
			tp_int = n;

            switch (n)
            {
                // 
                case 0:
                    break;

                // Caminar Dreta
				case 1:
					moveX = 1;
					anim.Play ("Krystal_Walk");
                    break;

                // Caminar Esquerra
                case 2:
                    moveX = -1;
					anim.Play ("Krystal_Walk");
                    break;
                // Projectil
                case 3:
                    anim.Play("castHeart");
                    numProj = 1;
                    break;
                case 4:
                    anim.Play("castHeart");
                    numProj = 3;
                    break;
                // TP Abaix Esquerra
                case 5:
				// TP Abaix Dreta
                case 6:
				// TP Adalt Esquerra
				case 7:
				// TP Adalt Dreta
				case 8:
					anim.Play("Krystal_Idle_2");
					Instantiate (_tp, transform.position - new Vector3(0.0f, 0.8f, 0.0f), Quaternion.identity);
                    break;
				// Beam
				case 9:
					anim.Play ("castBeam");
                    marker = false;
					break;
                case 10:
                    anim.Play("castBeam");
                    marker = true;
                    break;

            }
        }
    }

	private void teleport(){
		switch (tp_int)
		{

			// TP Abaix Esquerra
			case 5:
				transform.position = GameObject.Find ("Marker_DL").transform.position;
				break;
			// TP Abaix Dreta
			case 6:
				transform.position = GameObject.Find ("Marker_DR").transform.position;
				break;
			// TP Adalt Esquerra
			case 7:
				transform.position = GameObject.Find ("Marker_UL").transform.position;
				break;
			// TP Adalt Dreta
			case 8:
				transform.position = GameObject.Find ("Marker_UR").transform.position;
				break;
		}
		action = false;
	}

	public void hurt(){
        hp--;
        if (hp > 0)
        {
            hit = true;
            anim.Play("Krystal_Damage");
        }
        else
        {
            dead = true;
            anim.Play("death");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Birgin_Controller>().enabled = false;
            Instantiate(_tp, transform.position - new Vector3(0.0f, 0.8f, 0.0f), Quaternion.identity);
        }
    }

	public void castBeam()
	{
        if (marker)
        {
            GameObject[] markers = GameObject.FindGameObjectsWithTag("BeamMarker");

            for (int n = 0; n < markers.Length; n++)
            {
                Instantiate(_beam, markers[n].transform.position - new Vector3(0.0f, 0.6f, 0.0f), Quaternion.identity);
            }
        }
        else
        {
            Instantiate(_beam, GameObject.FindGameObjectWithTag("Player").transform.position - new Vector3(0.0f, 0.6f, 0.0f), Quaternion.identity);
        }
	}

	public void castHeart()
	{
        if (numProj > 0)
        {
            Instantiate(_projectile, transform.position, Quaternion.identity);
        }
        numProj--;
	}

	public void turn180()
	{
		lookL = !lookL;
		lookR = !lookR;
		transform.Rotate(new Vector3(0, 180, 0));
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Marker"){

			moveX = 0;

			if (other.name == "Marker_DL" && lookL) {
				lookL = false;
				lookR = true;
				transform.Rotate(new Vector3(0, 180, 0));
			}

			if(other.name == "Marker_DR" && lookR){
				lookL = true;
				lookR = false;
				transform.Rotate(new Vector3(0, 180, 0));
			}
			if (other.name == "Marker_UL" && lookL) {
				lookL = false;
				lookR = true;
				transform.Rotate(new Vector3(0, 180, 0));
			}

			if(other.name == "Marker_UR" && lookR){
				lookL = true;
				lookR = false;
				transform.Rotate(new Vector3(0, 180, 0));
			}


		}

	}

	public bool isAttacking()
	{
		return action;
	}

	public void setHitFalse()
	{
		hit = false;
	}

	public void setActionFalse()
	{
		action = false;
	}

    public void destroyObject()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Birgin_Controller>().enabled = true;
        Instantiate(phaseBoss, GameObject.Find("SpawnBoss").transform.position , Quaternion.Euler(0,-90,0));
        Destroy(gameObject);
    }
}
