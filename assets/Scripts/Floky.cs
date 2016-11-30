using UnityEngine;
using System.Collections;

public class Floky : MonoBehaviour
{
    public int movementspeed = 1;
    public float speed = 0.01f;
    public float _jumpSpeed;
    public float _gravity;
    public float amplitude = 2f;
    public float frequency = 0.05f;
    public CharacterController controller;

    public bool knockPlayer;

	private bool chargeFlag = false;
	private float charge = 0;
	public float _chargeTime = 0.1f;
	public bool is_boss = false;
	public Color color = new Color(0.2F, 0.3F, 0.4F, 1.0F);
	public Renderer rend;
	private bool chargeMove = false;
	public float _velCharge = 5;
	private bool chargeStop = false;



	public bool EnemyActive = true;


	public float randTime = 2.0f;
	// Variables de control de temps
	private float actualTime;
	private float prevTime;



	private Vector3 auxPosition;

	
	//Enemy attributes
    public float life;
    public float attack = 0.5f;
	

    // Use this for initialization
    void Start()
    {
		actualTime = Time.time;
		prevTime = 0;

        //rend = GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("Specular");
        //rend.material.SetColor("_SpecColor", color);

        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        GameObject Player = GameObject.Find("Player");
        //knockPlayer = Player.GetComponent<Sir_Birgin_Controller>().knock;
        //Debug.Log("Flocky dice:" + knockPlayer);
        Debug.Log(this.name);
        if (this.name == "Papa-Floky")
        {
            life = 15f;
        }
        else
        {
            life = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {

		if (EnemyActive)
		{
			actualTime = Time.time;
			if (actualTime - prevTime > randTime)
			{
				prevTime = actualTime;

				int action = Random.Range(1, 5);
				//print (action);
				//print ("aaa");
				DoAction(action);
			}
		}

        //Debug.Log("Flocky dice:" + knockPlayer);
		auxPosition = transform.position;
        transform.position += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.forward;


		// Funcio que es cridara quan sigui atac de Dash
        if (chargeFlag) {

			charge += _chargeTime;
			color = new Color (charge, 0.0F, 0.0F, 1.0F);
			//rend.material.SetColor ("_SpecColor", color);

			if (charge >= 1.0F) {
				color = new Color (0.2F, 0.3F, 0.4F, 1.0F);
				//rend.material.SetColor ("_SpecColor", color);

				charge = 0;
				chargeFlag = false;
				chargeMove = true;
			} 

		}

		if (chargeStop) {
			movementspeed = 0;

			StartCoroutine(WaitAndStop(0.7f));
		}

		if (chargeMove)
		{
			float movement = _velCharge * Time.deltaTime;
			if (transform.position.x - auxPosition.x > 0) {

				transform.Translate(Vector3.left * movement);
			}else{

				transform.Translate(Vector3.left * movement*-1);
			}

			
		}
		
		/*if (Input.GetKeyUp("up"))
		{
			chargeFlag = true;
			chargeMove = true;
		}
		if (Input.GetKeyUp("down"))
		{
			chargeStop = true;
		}
		*/

    }

    public void arrowImpact()
    {
        life -= 2;
        if (life <= 0)
        {
            if (this.gameObject.name == "Papa-Floky")
            {
                GameObject[] g = GameObject.FindGameObjectsWithTag("Barrera");
                Destroy(g[1]);
                Destroy(g[0]);
            }
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            //CharacterController control = col.GetComponent<CharacterController>();
            //control.SimpleMove( new Vector3(0f,30f,0f) );

            //Debug.Log(col.tag);

            /*if (col.GetComponent<Birgin_Controller>().hit)
            {
                //col.GetComponent<Birgin_Controller>().knockback(this.transform.position);
                col.GetComponent<Birgin_Controller>().hurt(1);
            }*/

        }
    }
	

	IEnumerator WaitAndStop(float waitTime)
	{
		chargeStop = false;
		chargeMove = false;

		yield return new WaitForSeconds(waitTime);
		movementspeed = 0;
		charge = 0;
		chargeFlag = false;
		//print ("wait and stop");
	}

	IEnumerator stop(float waitTime) 
	{
		
		yield return new WaitForSeconds(waitTime);
		chargeStop = true;
	}

	IEnumerator MoveLeft(float waitTime) 
	{

		yield return new WaitForSeconds(waitTime);
	}

	IEnumerator MoveRight(float waitTime) 
	{
		
		yield return new WaitForSeconds(waitTime);
	}


	public void DoAction(int n)
	{
		if (EnemyActive)
		{
			switch (n)
			{
				// Salt
			case 0:
				//jumpFlag = true;

				break;
				
				// Moure Dreta
			case 1:
				//moveX = 1;

				StartCoroutine(MoveRight(0.7f));
				break;
				
				// Moure Esquerra
			case 2:
				//moveX = -1;

				StartCoroutine(MoveLeft(0.7f));
				break;
				
				// Dispar
			case 3:
				//cargar
				chargeFlag = true;
				chargeMove = true;
				StartCoroutine(stop(0.2f));
				break;
			case 10:
				//print("death");
				break;
			}
		}
	}

	
}