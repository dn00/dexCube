using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	Vector3 startPosition0;
	Vector3 startPosition1;
	Vector3 leftPosition0;
	Vector3 rightPosition0;
	Vector3 leftPosition1;
	Vector3 rightPosition1;
	public GameObject leftParticles;
	public GameObject rightParticles;
	float leftBorder;
	float rightBorder;
	bool doubleKey = false;
	public float speed = 13.0f;
	public float leftRightPosWidth = 0.4f;
	public GameObject leftChild;
	//private int state;
	// Use this for initialization
	void Start () {
		float dist =(transform.position.y - Camera.main.transform.position.y);
		//Vector3 vLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0.01f,dist));
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.0f,0.0f,-6.0f)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1.0f,0.0f,-6.0f)).x;
		startPosition1 = new Vector3(-0.5f,-3.5f,0);
		startPosition0 = new Vector3(0.5f,-3.5f,0);
		leftPosition0 = new Vector3(-3.0f ,-3.5f,0);
		rightPosition0 = new Vector3(4.0f,-3.5f,0);
		leftPosition1 = new Vector3(-4.0f ,-3.5f,0);
		rightPosition1 = new Vector3(3.0f,-3.5f,0);
	}
	
	// Update is called once per frame
	void Update () {
		 //    if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
			// {		
			// 	dual();
	  //  		}
			// else
			// {
			// 		doubleKey = false;
			// }
			// if (Input.GetKey(KeyCode.A) && doubleKey == false)
			// {
			// 	left();
	  //  		}
	  //  		else if (Input.GetKey(KeyCode.D) && doubleKey == false)
	  //  		{
	  //  			right();
	  //  		}
	  //  		else if (doubleKey == false)
	  //  		{
	  //  			def();
	  //  		}
	   		
	   	
	   		if (Input.touchCount > 0)
				{
				    Touch touch = Input.GetTouch(0);
				    if (Input.touchCount > 1)
				    {
				    	dual();
				    }
				    else
					{
					doubleKey = false;
					}
				    if (touch.position.x < Screen.width/2 && doubleKey == false)
				    {
				        left();
				    }
				    else if (touch.position.x > Screen.width/2 && doubleKey == false)
				    {
				        right();
				    }
				}
				else if (Input.touchCount  == 0)
	   				{
	   					def();
	   				}

	}
	void OnCollisionEnter(Collision theCollision){
 		if(theCollision.gameObject.tag == "obstacles"){
  			Application.LoadLevel ("playScene");
 		}
 	
 	
	 }
	 void dual()
	 {
	 	doubleKey = true;
		leftChild.transform.position = Vector2.MoveTowards(leftChild.transform.position, new Vector2(-4,-3.5f), speed * Time.deltaTime);
		transform.position = Vector2.MoveTowards(transform.position, new Vector2(4,-3.5f), speed * Time.deltaTime);
	   					//state = 3;
	   							//splitScale();
	    leftParticles.GetComponent<ParticleSystem>().enableEmission = true;
	    rightParticles.GetComponent<ParticleSystem>().enableEmission = true;
	 }
	 void left()
	 {
	 	transform.position = Vector2.MoveTowards(transform.position, leftPosition0, speed * Time.deltaTime);
	   	leftChild.transform.position = Vector2.MoveTowards(leftChild.transform.position, leftPosition1, speed * Time.deltaTime);
	   	leftParticles.GetComponent<ParticleSystem>().enableEmission = true;
	   	rightParticles.GetComponent<ParticleSystem>().enableEmission = false;
	   //	particleSystem.enableEmission = false;
	 }
	 void right()
	 {
	 	transform.position = Vector2.MoveTowards(transform.position, rightPosition0, speed * Time.deltaTime);
	   	leftChild.transform.position = Vector2.MoveTowards(leftChild.transform.position, rightPosition1, speed * Time.deltaTime);
	     leftParticles.GetComponent<ParticleSystem>().enableEmission = false;
	   	rightParticles.GetComponent<ParticleSystem>().enableEmission = true;
	 }
	 void def()
	 {
	 	transform.position = Vector3.MoveTowards(transform.position, startPosition0 , speed * Time.deltaTime);
	    leftChild.transform.position = Vector2.MoveTowards(leftChild.transform.position, startPosition1, speed * Time.deltaTime);
	   	//state = 0;
	   	//defaultScale();
	   	 leftParticles.GetComponent<ParticleSystem>().enableEmission = false;
	   	rightParticles.GetComponent<ParticleSystem>().enableEmission = false;
	 }
}
