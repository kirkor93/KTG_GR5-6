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
        //if (other.gameObject.tag == "Terrain")
        {
            Debug.Log("Collision!");
            PlayerController.instance.Smoke();
            Destroy(this.gameObject);
        }
    }
}
