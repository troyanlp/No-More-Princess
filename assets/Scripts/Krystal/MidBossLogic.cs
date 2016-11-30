using UnityEngine;
using System.Collections;

public class MidBossLogic : MonoBehaviour {

    public MidBossAction bossScript;
    public float randTime = 2.0f;

    public bool bossActive = true;

	private int[] pattern;
	private int pattern_itr;

    // Variables de control de temps
    private float actualTime;
    private float prevTime;

	// Use this for initialization
	void Start () {
		pattern = new int[] {2,3,1,3,3,3,2,3,1,3,2,3,3,3,1,9};
        enabled = false;
		//pattern_itr = Random.Range(0, pattern.Length-1);
		pattern_itr = 0;

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
