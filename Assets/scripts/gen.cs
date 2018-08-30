using UnityEngine;
using System.Collections;
using PathologicalGames;

public class gen : MonoBehaviour {
	public GameObject spikeRight;
	public GameObject spikeLeft;
	public GameObject scoreInc;
	public GameObject mid;
	public GameObject dual;
	Vector2 v2;
	float spawnTime = 1.0f;
    public int score = 0;
    public float speed = 10.0f;
    private int level = 0;
    public GameObject scoreTemp;
	// Use this for initialization
	void Start () {
		v2 = GetComponent<Camera>().ScreenToWorldPoint (new Vector2 (Screen.width,Screen.height));
		//InvokeRepeating("generate", 0.1f, spawnTime);
		 StartCoroutine(Do());
	}
	 IEnumerator Do() {
	 	while(true) {
      	  yield return new WaitForSeconds(spawnTime);
       		 generate();
    	}
	}
	// Update is called once per frame
	void Update () {
	}

	void generate()
	{
		int rand = Random.Range(0,4);
		if (rand == 0)
		{
			PoolManager.Pools["obs"].Spawn(spikeLeft.transform, spikeLeft.transform.position, transform.rotation);
		}
		else if (rand == 1)
		{
			PoolManager.Pools["obs"].Spawn(spikeRight.transform, spikeRight.transform.position, transform.rotation);
		}
		else if (rand == 2)
		{

			PoolManager.Pools["obs"].Spawn(mid.transform, mid.transform.position, transform.rotation);
		}
		else if (rand == 3)
		{

			PoolManager.Pools["obs"].Spawn(dual.transform, dual.transform.position, transform.rotation);
		}

		if (score > 0 && score % 5 == 0)
		{
			++level;
			speedInc();
		}
	}
	public void plusScore()
	{
		++score;
		scoreTemp.GetComponent<GUIText>().text = score.ToString();
		//print(score);
	}
	void speedInc()
	{ 
		// float speedTemp = speed * 0.08f;
		// speed+= speedTemp;
		// float spawnTemp = spawnTime * 0.08f;
		// spawnTime-= spawnTemp;

		if (level == 1) // 15
		{
			spawnTime = 0.9f;
			speed = 11.5f;
		}
		if (level == 2) // 35
		{
			spawnTime =0.8f;
			speed = 13.5f;
		}
		if (level == 3) // 55
		{
			spawnTime = 0.7f;
			speed = 15.5f;
		}
		if (level == 4) // 55
		{
			spawnTime = 0.6f;
			speed = 17.5f;
		}
			if (level == 5) // 55
		{
			spawnTime = 0.52f;
			speed = 19.5f;
		}
			if (level == 6) // 55
		{
			print("level6");
			spawnTime = 0.45f;
			speed = 21.5f;
		}
	}

}
