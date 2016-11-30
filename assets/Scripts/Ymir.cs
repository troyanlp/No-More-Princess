using UnityEngine;
using System.Collections;

public class Ymir : MonoBehaviour {

	public int movementspeed = 100;
	public float speed = 0.1f;
	public float _jumpSpeed;
	public float _gravity;
	public float amplitude = 1f;
	public float frequency = 0.05f;
	public CharacterController controller;
	private Animator anim;
	public float hp = 3;

	public bool right = true;
	public bool left = false;

	private float actualTime;
	private float prevTime;
	public float randTime = 2.0f;

	private int moveX = 0;

	public bool EnemyActive = true;

	private Vector3 auxPosition;



	//Enemy attributes
	public float attack = 0.5f;

	private bool atack = false;




	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0F;

    public float deathTimer = 0f;




	
	// Use this for initialization
	void Start () {
		actualTime = Time.time;
		prevTime = 0;

		Physics.gravity = new Vector3(0f, -9.81f, 0f);
		anim = GetComponent<Animator>();	
	
	}
	
	// Update is called once per frame
	void Update () {


			moveDirection = new Vector3(moveX, 0, 0);
		//print (moveDirection);
		//moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		moveDirection.y -= gravity * Time.deltaTime;

        //controller.Move(moveDirection * Time.deltaTime);

        if (hp <= 0)
        {
            deathTimer += 0.1f;
        }

        if (deathTimer >= 20f)
        {
            Destroy(this.gameObject);
        }


        int action = Random.Range(1, 5);
		
		if (EnemyActive) {

            

            actualTime = Time.time;
			if (actualTime - prevTime > randTime) {
				prevTime = actualTime;

				//print (action);
				DoAction(action);
			}
		
			if (action == 2 || action == 1) {
				auxPosition = transform.position;
				transform.position += amplitude * (Mathf.Sin (2 * Mathf.PI * frequency * Time.time) - Mathf.Sin (2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.right;

			}

			if (hp == 0) {
				DoAction (10);
			}


			if (Input.GetKeyUp ("up")) {
				DoAction (9);
			}
			if (Input.GetKeyUp ("left")) {
				//print ("left");
			}
			if (Input.GetKeyUp ("right")) {
				//print ("right");
			}

			if (Input.GetKeyUp ("down")) {
				atack = true;
				anim.Play ("Ymir hit", -1, 0f);
			}
		}



	}

	IEnumerator WaitAndStop(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		//moveX = 0;
	}
	
	IEnumerator MoveLeft(float waitTime) 
	{

		yield return new WaitForSeconds(waitTime);
	}
	
	IEnumerator MoveRight(float waitTime) 
	{

		yield return new WaitForSeconds(waitTime);
	}

	IEnumerator WaitAndAttack(float waitTime) 
	{
		
		yield return new WaitForSeconds(waitTime);
	}

	IEnumerator WaitAndHit(float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		hurted ();
	}

	IEnumerator WaitAndDie(float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		EnemyActive = false;
        
	}

	public void DoAction(int n)
	{
		if (EnemyActive) {
			switch (n) {
			// Salt
			case 0:
				//jumpFlag = true;
				
				break;
				
			// Moure Dreta
			case 1:
				moveX = 1;

				if (left == true) {
					transform.Rotate(new Vector3(0, 180, 0));
				}
				
				right = true;
				left = false;
				//print ("dreta");
				StartCoroutine(WaitAndStop(2.0f));
				//StartCoroutine (MoveRight (0.7f));
				break;
				
			// Moure Esquerra
			case 2:
				moveX = -1;
				if ( right == true) {
					transform.Rotate(new Vector3(0, 180, 0));
				}

				left = true;
				right = false;
				
				//print ("esquerra");
				StartCoroutine(WaitAndStop(2.0f));
				//StartCoroutine (MoveLeft (0.7f));
				break;
				
			// Dispar
			case 3:
				//atac
				atack = true;
				anim.Play ("Ymir Atac", -1, 0f);
				StartCoroutine (WaitAndAttack (0.7f));
				break;
			case 9:
				//hitted

				StartCoroutine (WaitAndHit (0.7f));
				break;
			case 10:
				//print("death");
				anim.Play ("Ymir death", -1, 0f);
				StartCoroutine (WaitAndDie (0.7f));
                    //Destroy(this.gameObject);
                    break;
			}
		}
	}
	public void hurted()
	{
        if (EnemyActive)
        {
            hp--;
            anim.Play("Ymir hit", -1, 0f);
        }
        
	}

	void OnTriggerEnter(Collider otherObject)
	{		
		//Si és el player
		if (otherObject.tag == "Player")
		{
			Destroy(gameObject);
			//otherObject.GetComponent<Sir_Birgin_Controller>().hurt(0.5f);
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		
		if (hit.collider.tag == "Player")
		{
			anim.Play("Damage");
			hit.collider.GetComponent<Birgin_Controller>().hurt(1);
		
		}
		
	}
	
}
