using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	//public variables
	private float rotationSpeed;

	// Use this for initialization
	void Start () {
		rotationSpeed = 180.0f;
		//StartCoroutine ("waitToDestroy");
	}
	
	// Update is called once per frame
	void Update () {
		//probability can't be more than 1 or less than 0

		transform.Rotate (Vector3.forward, Time.deltaTime * rotationSpeed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			Inventory.CoinCount++;
			Destroy(this.gameObject);
		}
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

	IEnumerator waitToDestroy()
	{
		yield return new WaitForSeconds(2.0f);
		Destroy (this.gameObject);
	}
}
