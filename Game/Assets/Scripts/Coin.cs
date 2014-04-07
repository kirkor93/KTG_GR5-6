using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	//public variables
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward, Time.deltaTime * rotationSpeed);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("I'm here");
		if (other.gameObject.tag == "Player")
		{
			Inventory.CoinCount++;
			Destroy(this.gameObject);
		}
	}
}
