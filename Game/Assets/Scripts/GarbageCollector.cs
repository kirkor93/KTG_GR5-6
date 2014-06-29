using UnityEngine;
using System.Collections;

public class GarbageCollector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
        float time = 0.0f;
        if(other.gameObject.tag == "Terrain")
        {
            time = 20.0f;
        }
        Destroy(other.gameObject, time);
	}
}
