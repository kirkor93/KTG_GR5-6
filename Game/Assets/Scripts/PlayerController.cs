using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
			
	bool isAlive;
//	bool isDrunk;
//	float drunkTime;
//	float drunkAngle;
	float distance = 10.0f;
	int currentLane;
	public float speed;
	public float deathDelay = 2.0f;
	public GameObject player;
		
	// Use this for initialization
	void Start()
	{
		this.isAlive = true;
//		this.isDrunk = false;
		this.currentLane = 0;
	}
		
	void OnCollisionEnter(Collision other)
	{
			
	}
		
	// Update is called once per frame
	void Update()
	{
		if (isAlive) 
		{

			//rigidbody.MovePosition(new Vector3(0,0,-1*speed*Time.deltaTime));
			//player.transform.Translate (new Vector3 (0, 0, -1 * speed * Time.deltaTime));
			//rigidbody.AddForce (new Vector3 (0, 0, -1 * speed), ForceMode.VelocityChange);
			if(Input.GetKeyDown("left") && currentLane!=-1)
			{
				Debug.Log("skrecam w lewo");
				transform.Translate(new Vector3(1*distance,0,0));
				currentLane-=1;
			}
			if(Input.GetKeyDown("right") && currentLane!=1)
			{
				Debug.Log("Skrecam w prawo");
				transform.Translate(new Vector3(-1*distance,0,0));
				currentLane+=1;
			}
		
		}
	}	
		
	IEnumerator Death()
	{
		yield return new WaitForSeconds(deathDelay);
		this.isAlive = false;
		Application.LoadLevel("DeathScreen");
	}
		
	IEnumerator WhiskeyInAJar(float whisky)
	{
		//this.isDrunk = true;
		//drunkTime = whisky;
		//drunkAngle = 360.0f / whisky;
		yield return null;
	}
		
	

}
