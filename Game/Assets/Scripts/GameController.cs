using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject Train;
	public GameObject StraightLine;
	public GameObject RightLineHole;
	public GameObject LeftLineHole;
	public float HoleProbability = 0.3f;

	private GameObject currentLine;
	private float lineEnding;

    public float MiscCooldown = 0.8f;
    private float cooldown = 0.0f;
    public float SignProbability = 0.5f;
    public float CactusProbability = 0.9f;
    public GameObject CactusPrefab;
    public GameObject SignPrefab;

	// Use this for initialization
	void Start () {
		currentLine = GameObject.Find (StraightLine.gameObject.name);
        lineEnding = currentLine.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        cooldown += Time.deltaTime;
        if (cooldown > MiscCooldown)
        {
            cooldown = 0.0f;
            int what = Random.Range(0, 2);
            float misc = Random.Range(0, 10000);
            misc /= 10000.0f;
            float posX = Random.Range(2000, 5000);
            posX /= 100.0f;
            int plusMinus = Random.Range(0, 2);
            if (plusMinus == 0)
            {
                posX = -posX;
            }
            if (what == 0)
            {
                if (misc > (1 - CactusProbability))
                {
                    Instantiate(CactusPrefab, new Vector3(posX, 2.730092f, Train.transform.position.z - 30.0f), CactusPrefab.transform.rotation);
                }
            }
            else
            {
                if (misc > (1 - SignProbability))
                {
                    Instantiate(SignPrefab, new Vector3(posX, 1.970203f, Train.transform.position.z - 30.0f), SignPrefab.transform.rotation);
                }
            }
        }

        if (Train.transform.position.z - 60.0f < lineEnding)
        {
            float p = Random.Range(0, 10000);
            p /= 10000.0f;
            if (p >= (1 - HoleProbability))
            {
                int x = Random.Range(0, 2);
                if (x == 0)
                {
                    currentLine = Instantiate(LeftLineHole, new Vector3(0, 0, currentLine.transform.position.z - 150.0f), Quaternion.identity) as GameObject;
                }
                else
                {
                    currentLine = Instantiate(RightLineHole, new Vector3(0, 0, currentLine.transform.position.z - 150.0f), Quaternion.identity) as GameObject;
                }
                currentLine.transform.Rotate(Vector3.up, 90.0f);
                lineEnding -= 120.0f;
            }
            else
            {
                currentLine = Instantiate(StraightLine, new Vector3(0, 0, currentLine.transform.position.z - 150.0f), Quaternion.identity) as GameObject;
                currentLine.transform.Rotate(Vector3.up, 90.0f);
                lineEnding = 120.0f;
            }
        }
	}
}
