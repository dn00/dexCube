using UnityEngine;
using System.Collections;

public class playerOneScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision theCollision){
 		if(theCollision.gameObject.tag == "obstacles"){
  			Application.LoadLevel ("playScene");
 		}
 	}
}
