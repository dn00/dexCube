using UnityEngine;
using System.Collections;
using PathologicalGames;

public class obstacles : MonoBehaviour {
	public float speed;
	private float speedFloat;
	//Vector2 v2;
	// Use this for initialization
	void Start () {
		speedFloat = Camera.main.GetComponent<gen>().speed;
		speed = speedFloat;
	}
	
	// Update is called once per frame
	void Update () {
		speedFloat = Camera.main.GetComponent<gen>().speed;
		speed = speedFloat;
		transform.Translate(0, -Time.deltaTime * speed, 0);
	}
	void OnBecameInvisible()
	{   
		PoolManager.Pools["obs"].Despawn(gameObject.transform);
	}
}

