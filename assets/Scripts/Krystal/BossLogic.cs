using UnityEngine;
using System.Collections;

public class BossLogic : MonoBehaviour {

    public BossAction bossScript;
    public float randTime = 2.0f;

    public bool bossActive = true;

	private int[] pattern;
	private int pattern_itr;

    // Variables de control de temps
    private float actualTime;
    private float prevTime;

	// Use this for initialization
	void Start () {
		pattern = new int[] {2,4,7,10,8,9,5,1,4,2,4,8,10,7,9,6,2,7,3,8,4,9,4,10,3,4,3,6};

		//pattern_itr = Random.Range(0, pattern.Length-1);
		pattern_itr = 0;
        enabled = false;
        actualTime = Time.time;
        prevTime = 0;
    }

    // Update is called once per frame
    void Update () {

        actualTime = Time.time;
        if (actualTime - prevTime > randTime)
        {
            prevTime = actualTime;
			if(!bossScript.isAttacking()){
				bossScript.DoAction (pattern [pattern_itr]);
				pattern_itr++;
				if (pattern_itr >= pattern.Length) {
					pattern_itr = 0;
				}

			}
        }

	}

    public void awakeBoss()
    {
        bossScript.enabled = true;
        enabled = true;
    }
}
