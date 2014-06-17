using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {
	public float rotationSpeed;
	public float speed;
	public ParticleSystem explo;
	
	void Start () {
	}

	void Update () {
		transform.Rotate (Vector3.forward, Time.deltaTime * rotationSpeed);
	}

	void FixedUpdate(){
		rigidbody.velocity = speed* Vector3.forward;	
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			instantiate(explo, this.transform.position);
			Destroy(this.gameObject);
			other.SendMessage("Death");
		}
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position){
		Vector3 wek = new Vector3 (position.x, position.y + 1, position.z - 1);
		ParticleSystem newParticleSystem = Instantiate(prefab,wek,Quaternion.identity) as ParticleSystem;
		Destroy(newParticleSystem.gameObject,newParticleSystem.startLifetime);
		return newParticleSystem;
	}


}
