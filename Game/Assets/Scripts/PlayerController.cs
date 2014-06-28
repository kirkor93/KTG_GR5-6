using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
			
	bool isAlive;
//	bool isDrunk;
//	float drunkTime;
//	float drunkAngle;
	float distance = 10.0f;
	bool isTurning;
	int currentLane;
	Vector3 playerPos;
	Vector3 newPos;
	Quaternion playerRot;
	Quaternion newRot;
	Quaternion zeroRot;
	public float speed;
	public float deathDelay = 2.0f;
	public float turningMultiplier = 5.0f;
	public GameObject player;
		
	// Use this for initialization
	void Start()
	{
		this.isAlive = true;
//		this.isDrunk = false;
		this.currentLane = 0;
		this.playerPos = transform.position;
		this.playerRot = transform.rotation;
		this.zeroRot = transform.rotation;
		isTurning = false;
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
			player.transform.Translate (new Vector3 (0, 0, -1 * speed * Time.deltaTime));
			playerPos = transform.position;
			playerRot = transform.rotation;
			//this.transform.Translate (new Vector3 (0, 0, -1 * speed * Time.deltaTime));
			//rigidbody.AddForce (new Vector3 (0, 0, -1 * speed), ForceMode.VelocityChange);
			if(!isTurning  && Input.GetKeyDown("left") && currentLane >-1)
			{
				isTurning = true;
				Debug.Log("skrecam w lewo");
				newPos = new Vector3 (playerPos.x+distance, playerPos.y, playerPos.z);
				newRot = new Quaternion(playerRot.x,playerRot.y,playerRot.z-0.2f,playerRot.w);
				currentLane -=1;
			}
			if(!isTurning && Input.GetKeyDown("right") && currentLane <1)
			{
				isTurning = true;
				Debug.Log("Skrecam w prawo");
				newPos = new Vector3 (playerPos.x-distance, playerPos.y, playerPos.z);
				newRot = new Quaternion(playerRot.x,playerRot.y,playerRot.z+0.2f,playerRot.w);
				currentLane+=1;
			}

			if(isTurning)
			{
				newPos.y=playerPos.y;
				newPos.z=playerPos.z;
				transform.position = Vector3.MoveTowards (playerPos,newPos,turningMultiplier*speed*Time.deltaTime);
				if((newPos.x-playerPos.x)>1) transform.rotation = Quaternion.RotateTowards(playerRot,newRot,3.0f);
				else if ((newPos.x-playerPos.x)>0) transform.rotation = Quaternion.RotateTowards(playerRot,zeroRot,10.0f);
				if((newPos.x-playerPos.x)<-1)transform.rotation = Quaternion.RotateTowards(playerRot,newRot,-3.0f);
				else if ((newPos.x-playerPos.x)<0) transform.rotation = Quaternion.RotateTowards(playerRot,zeroRot,10.0f);
				if(transform.position == newPos)
				{
					isTurning = false; 
				}
			}
		}
	}	

	void FixedUpdate()
	{

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
