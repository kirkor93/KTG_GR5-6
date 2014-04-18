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
                coinPos.x = coinLane * 2.5f;
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
            Vector3 barrelPosition = barrelPrefab.transform.position;
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
                rampPosition.x = -2.5f;
            }
            else
            {
                rampPosition.x = 2.5f;
            }
            rampPosition.z = transform.position.z - 20;
            Instantiate(rampPrefab, rampPosition, rampPrefab.transform.rotation);
        }
    }
}
