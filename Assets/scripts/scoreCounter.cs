using UnityEngine;
using System.Collections;

public class scoreCounter : MonoBehaviour {
	private gen genScript;
	// Use this for initialization
	void Start () {
		genScript = Camera.main.GetComponent<gen>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider theCollision){
 		if(theCollision.gameObject.tag == "obstacles"){
  			genScript.plusScore();
 		}
	}
}
