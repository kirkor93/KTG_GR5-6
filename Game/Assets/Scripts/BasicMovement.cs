using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {

	public float rotationSpeed;
	public float movementSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(0, 0, movementSpeed);
		}
		else if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(0, 0, -movementSpeed);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			transform.Rotate(new Vector3(0,1,0),rotationSpeed);
		}
		else if(Input.GetKey(KeyCode.A))
		{
			transform.Rotate(new Vector3(0,1,0),-rotationSpeed);
		}
	}
}
