using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public static int CoinCount;
	public GUIText coins;

	// Use this for initialization
	void Start () {
		CoinCount = 0;
		coins.text = CoinCount.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		coins.text = CoinCount.ToString ();
	}
}
