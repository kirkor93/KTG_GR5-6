using UnityEngine;
using System.Collections;

public class TNT : MonoBehaviour {
    public ParticleSystem explo;

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
        if (other.gameObject.tag == "Player")
        {
            instantiate(explo, this.transform.position);
            Destroy(this.gameObject);
            other.gameObject.SendMessage("Death");
        }
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        Vector3 wek = new Vector3(position.x, position.y + 1, position.z - 1);
        ParticleSystem newParticleSystem = Instantiate(prefab, wek, Quaternion.identity) as ParticleSystem;
        Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);
        return newParticleSystem;
    }
}
