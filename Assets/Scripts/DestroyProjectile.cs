using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {

	public GameObject explosion;
	public float explosionForce = 1000f;
	public float explosionRadius = 5f;

	void Start () {
		Destroy (gameObject, 30f);
	}

	void Explode ()
	{
		Collider [] objectsNearby = Physics.OverlapSphere (transform.position, explosionRadius);
		foreach (var c in objectsNearby) 
		{
			Rigidbody rb = c.GetComponent<Rigidbody> ();
			if (rb != null) 
			{
				rb.AddExplosionForce (explosionForce, transform.position, explosionRadius); 
			}
		}

		Object explosionObject = Instantiate (explosion, transform.position, transform.rotation);
		Destroy (explosionObject, 10f);
	}
		
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") 
		{
			
			Destroy (gameObject);
		}
	}

	void OnDestroy()
	{
		Explode ();
	}

}
