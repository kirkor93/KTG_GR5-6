using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject Train;
	public GameObject StraightLine;
	public GameObject RightLineHole;
	public GameObject LeftLineHole;
	public float HoleProbability = 0.7f;

	private GameObject currentLine;
	private float lineEnding;

	// Use this for initialization
	void Start () {
		currentLine = GameObject.Find ("Straight");
		lineEnding = currentLine.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if(Train.transform.position.z - 3 < currentLine.transform.position.z - lineEnding)
		{
			float p = (float)Random.Range (0,10000) / 10000f;
			if(p > HoleProbability && Train.transform.position.z < -100f)
			{
				p = Random.Range (0,1000) / 1000;
				if(p>0.5f)
				{
					currentLine = Instantiate(RightLineHole, currentLine.transform.position+new Vector3(0,0,lineEnding),this.transform.rotation) as GameObject;
				}
				else
				{
					currentLine = Instantiate(LeftLineHole, currentLine.transform.position+new Vector3(0,0,lineEnding),this.transform.rotation) as GameObject;
				}
			}
			else
			{
				currentLine = Instantiate(StraightLine, currentLine.transform.position+new Vector3(0,0,lineEnding),currentLine.transform.rotation) as GameObject;
			}
		}
	}
}
