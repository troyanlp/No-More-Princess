using UnityEngine;
using System.Collections;

public class FinalBossAction : MonoBehaviour
{
    public float speed = 6.0F;
    public float gravity = 2.0F;
    public float hp = 3;

    public GameObject _projectile;
    public GameObject _beam;


    // Flags de control del Boss
	private bool lookL, lookR, hit, action, dead;
	private int moveX = 0;
	private int tp_int = 0;
    private int marker = 0;
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
        

		if (!dead)
		{
			if (controller.isGrounded)
			{
            }

            moveDirection.y = Mathf.Cos(2*Time.time)/3;
			controller.Move(moveDirection * Time.deltaTime);
		}
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

        }
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
                // Projectil
                case 1:
                    anim.Play("castHeart");
                    numProj = 1;
                    break;
                case 2:
                    anim.Play("castHeart");
                    numProj = 3;
                    break;
                // Beam
                case 3:
                    anim.Play("castBeam");
                    marker = 0;
                    break;
                case 4:
                    anim.Play("castBeam");
                    marker = 1;
                    break;
                case 5:
                    anim.Play("castBeam");
                    marker = 2;
                    break;
                case 6:
                    anim.Play("castBeam");
                    marker = 3;
                    break;

            }
        }
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
        }
    }

	public void castBeam()
	{
        if (marker == 3)
        {
            GameObject[] markers = GameObject.FindGameObjectsWithTag("BeamMarker");

            for (int n = 0; n < markers.Length; n++)
            {
                Instantiate(_beam, markers[n].transform.position - new Vector3(0.0f, 0.6f, 0.0f), Quaternion.identity);
            }
        }
        else if (marker == 2)
        {
            GameObject[] markers = GameObject.FindGameObjectsWithTag("BeamMarker");

            for (int n = 3; n < markers.Length; n++)
            {
                Instantiate(_beam, markers[n].transform.position - new Vector3(0.0f, 0.6f, 0.0f), Quaternion.identity);
            }
        }
        else if (marker == 1)
        {
            GameObject[] markers = GameObject.FindGameObjectsWithTag("BeamMarker");

            for (int n = 0; n < 4; n++)
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
        //GameObject.FindGameObjectWithTag("video3").transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;

        Instantiate(GameObject.FindGameObjectWithTag("video3"), GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
