using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {
	public float rotationSpeed;
	public float speed;
	
	void Start () {
		//Destroy (this.gameObject, 5);
	}

	void Update () {
		transform.Rotate (Vector3.up, Time.deltaTime * rotationSpeed);
	}

	void FixedUpdate(){
		rigidbody.velocity = speed* Vector3.forward;	
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
			other.SendMessage("Death");
		}
	}

}
