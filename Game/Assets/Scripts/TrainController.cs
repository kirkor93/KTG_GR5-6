using UnityEngine;
using System.Collections;

public class TrainController : MonoBehaviour
{

    public GameObject coinPrefab;
    public float coinProbability = 0.8f;
    public float coinDelay;
    float coinCooldown;
    Vector3 coinPos;
    int coinLane;
    int coinCount;

    public GameObject barrelPrefab;
    public float barrelDelay = 5.0f;
    float barrelCooldown;

    public GameObject rampPrefab;
    public float rampDelay = 10.0f;
    float rampCooldown;

    public float ForwardSpeed = 5.0f;

    float throwCooldown;
    public float throwDelay;
    public float tntProp;
    public GameObject tntPrefab;
    public float whiskeyProp;
    public GameObject whiskeyPrefab;

	public GameObject player;
	Vector3 target;

    // Use this for initialization
    void Start()
    {
        rampCooldown = rampDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // Forward Movement
        transform.Translate(0, 0, -ForwardSpeed * Time.deltaTime);

        // Coins
        while (coinProbability > 1.0f)
        {
            coinProbability--;
        }
        while (coinProbability < 0.0f)
        {
            coinProbability++;
        }

        if (coinCount <= 0)
        {
            int rndNumber = Random.Range(0, 10000);
            if ((float)rndNumber / 10000 >= coinProbability)
            {
                coinCooldown = 0;
                coinCount = Random.Range(3, 6);
                coinLane = Random.Range(0, 3) - 1;
                coinPos.x = coinLane * 10.0f;
                coinPos.y = coinPrefab.transform.position.y;
            }
        }
        else
        {
            coinCooldown += Time.deltaTime;
            if (coinCooldown >= coinDelay)
            {
                coinPos.z = this.transform.position.z;
                Instantiate(coinPrefab, coinPos, coinPrefab.transform.rotation);
                coinCount--;
                coinCooldown -= coinDelay;
            }
        }

        // Barrels
        barrelCooldown += Time.deltaTime;
        if (barrelCooldown >= barrelDelay)
        {
            barrelCooldown = 0;
			Vector3 barrelPosition = barrelPrefab.transform.position + new Vector3(-0.5f, 1.0f, 0.0f);
            barrelPosition.z = transform.position.z;
            Instantiate(barrelPrefab, barrelPosition, barrelPrefab.transform.rotation);
        }

        // Ramps
        rampCooldown += Time.deltaTime;
        if (rampCooldown >= rampDelay)
        {
            rampCooldown = 0;
            Vector3 rampPosition = rampPrefab.transform.position;
            int rampLane = Random.Range(0, 2);
            if (rampLane == 0)
            {
                rampPosition.x = -10.0f;
            }
            else
            {
                rampPosition.x = 10.0f;
            }
            rampPosition.z = transform.position.z - 20;
            Instantiate(rampPrefab, rampPosition, rampPrefab.transform.rotation);
        }

        // TNT
        throwCooldown += Time.deltaTime;
        if (throwCooldown >= throwDelay)
        {
            float tntRand = Random.Range(0, 100) / 100.0f;
            float whiskeyRand = Random.Range(0, 100) / 100.0f;
            int whatToThrow = 0;
			target = player.transform.position;

            if (tntRand >= (1.0f - tntProp) && whiskeyRand >= (1.0f - whiskeyProp))
            {
                whatToThrow = Random.Range(0, 2) + 1;
            }
            else if (tntRand >= (1.0f - tntProp))
            {
                whatToThrow = 1;
            }
            else if (whiskeyRand >= (1.0f - whiskeyProp))
            {
                whatToThrow = 2;
            }

            switch (whatToThrow)
            {
                // TNT
                case 1:
					target = player.transform.position;
                    Vector3 tntPos = transform.position;
                    tntPos.z += 1;
                    GameObject tnt = Instantiate(tntPrefab, tntPos, tntPrefab.transform.rotation) as GameObject;
                    tnt.rigidbody.AddForce(0.8f * target.x, 6, 7, ForceMode.Impulse); // lol, lucky shot for force vector
                    tnt.rigidbody.AddTorque(1, 2, 3);
                    break;
                // Whiskey
                case 2:
					target = player.transform.position;
                    Vector3 whiskeyPos = transform.position;
                    whiskeyPos.z += 1;
                    GameObject whiskey = Instantiate(whiskeyPrefab, whiskeyPos, whiskeyPrefab.transform.rotation) as GameObject;
                    whiskey.rigidbody.AddForce(0.8f * target.x, 6, 7, ForceMode.Impulse); // lol, lucky shot for force vector
                    whiskey.rigidbody.AddTorque(1, 2, 3);
                    break;
            }
            throwCooldown = 0;
        }
    }
}
