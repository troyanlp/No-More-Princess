using UnityEngine;
using System.Collections;

public class FinalBossLogic : MonoBehaviour {

    public FinalBossAction bossScript;
    public Krystal_Chest weakSpot;

    public float randTime = 1.5f;

    public bool bossActive = true;

	private int counter;

    // Variables de control de temps
    private float actualTime;
    private float prevTime;

	// Use this for initialization
	void Start () {

		counter = 0;

        actualTime = Time.time;
        prevTime = 0;

        StartCoroutine(awakeBoss());
    }

    // Update is called once per frame
    void Update () {

        actualTime = Time.time;
        if (actualTime - prevTime > randTime)
        {
            prevTime = actualTime;
            int action = Random.Range(1, 6);
            if (!bossScript.isAttacking()){
				
                if (counter == 5)
                {
                    action = 0;
                    counter = 0;
                    weakSpot.weakNotWeak();
                    StartCoroutine(notInvAnymore());
                }
                else
                {
                    counter++;
                }
                bossScript.DoAction(action);
            }
        }

	}

    IEnumerator awakeBoss()
    {
        yield return new WaitForSeconds(1f);
        bossScript.enabled = true;
    }

    IEnumerator notInvAnymore()
    {
        yield return new WaitForSeconds(2f);
        weakSpot.weakNotWeak();
    }
}
