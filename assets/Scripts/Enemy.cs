using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float life = 10;
    private bool asleep = false;

	// Use this for initialization
	void Start () {
        //asleep = true;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(track());

        //Debug.Log("El asleep de enemy es: " + this.asleep);

        if (track() <= 5)
        {
            //Debug.Log("Llamo a awaken");
            awaken();
        }

        if (this.track() > 5)
        {
            //Debug.Log("Llamo a gotosleep");
            goToSleep();
        }
	}

    public void takeDamage(float damage)
    {
        life -= damage;
        if(life <= 0)
        {
            Destroy(this.gameObject); // animación muerte, quizas esta comprobacion debe estar en el script del enemigo particular
        }
    }

    void awaken()
    {
        //Debug.Log("DESPIERTA");
        this.asleep = false;
    }

    void goToSleep()
    {
        //Debug.Log("a sobar!");
        this.asleep = true;
    }

    public float track()
    {

        //Vector3 P0 = GameObject.Find("Sir Birgin").transform.position;
        Vector3 P0 = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 P1 = transform.position;
        Vector3 moveDir = P0 - P1;
        float distance = Mathf.Sqrt(Mathf.Pow(moveDir.x,2) + Mathf.Pow(moveDir.y,2) + Mathf.Pow(moveDir.z,2));
        return distance;
    }

    public float getLife()
    {
        return life;
    }

    public bool getAsleep()
    {
        //Debug.Log("En el getAsleep es: " + this.asleep);
        return this.asleep;
    }


}
