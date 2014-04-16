using UnityEngine;
using System.Collections;

public class TrainController : MonoBehaviour {

	public GameObject coinPrefab;
	public float coinProbability = 0.8f;
	public GameObject barrelPrefab;
	public float barrelCooldown;
	public float barrelDelay = 5.0f;
    public float ForwardSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Forward Movement
        transform.Translate(0, 0, -ForwardSpeed * Time.deltaTime);

		while(coinProbability > 1.0f)
		{
			coinProbability--;
		}
		while(coinProbability < 0.0f)
		{
			coinProbability++;
		}

		int rndNumber = Random.Range (0, 10000);
		if((float)rndNumber/10000 >= coinProbability)
		{
			int lane = Random.Range (0,3) - 1;
			Vector3 coinPosition = this.transform.position;
			coinPosition.x = lane*2.5f;
			Instantiate(coinPrefab, coinPosition, coinPrefab.transform.rotation);
		}

		///// barrel///
		barrelCooldown += Time.deltaTime;
		if (barrelCooldown >= barrelDelay) {
			barrelCooldown=0;
			Vector3 barrelPosition = this.transform.position;
			Instantiate (barrelPrefab,barrelPosition, barrelPrefab.transform.rotation);
		}
	}
}
