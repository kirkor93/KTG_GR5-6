using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	//public variables
	private float rotationSpeed;

	// Use this for initialization
	void Start () {
		rotationSpeed = 180.0f;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (Vector3.left, Time.deltaTime * rotationSpeed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			Inventory.CoinCount++;
			Destroy(this.gameObject);
		}
	}
}
