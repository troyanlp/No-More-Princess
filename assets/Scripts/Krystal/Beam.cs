using UnityEngine;
using System.Collections;

public class Beam : MonoBehaviour
{

    //Velocitat
    public float _velocitat;
	public GameObject _beamRay;

    // Use this for initialization
    void Start()
    {
		StartCoroutine (DestroySprite());
    }

    // Update is called once per frame
    void Update()
    {
		/*
        // 

        float movement = _velocitat * Time.deltaTime;
        transform.Translate(Vector3.up * movement);
        
        //Si el projectil esta fora de pantalla el destruim
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider>().bounds))
        {
            Destroy(gameObject);
        }
		*/
    }

	IEnumerator DestroySprite()
	{
		yield return new WaitForSeconds(1.1f);
		Instantiate (_beamRay, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
		
}
