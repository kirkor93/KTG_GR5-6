using UnityEngine;
using System.Collections;

public class TNT : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        //Particles !!
        Destroy(this.gameObject);
    }
}
