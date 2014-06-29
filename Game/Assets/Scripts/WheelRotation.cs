using UnityEngine;
using System.Collections;

public class WheelRotation : MonoBehaviour {

	public float speed = 5.0f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//rigidbody.MoveRotation(new Quaternion(this.transform.rotation.x,this.transform.rotation.y,
		                                     // this.transform.rotation.z*speed*Time.deltaTime,this.transform.rotation.w));
        this.transform.Rotate(Vector3.forward, speed*Time.deltaTime);
	}
}
